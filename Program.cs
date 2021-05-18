using System;

namespace ChessCorrectMove
{
    // Дана начальная и конечная клетки на шахматной доске. Корректный ли это ход на пустой доске для: слона, коня, ладьи, ферзя, короля?
    class Program
    {
        static void Main(string[] args)
        {
            Rook r = new Rook('a', 1);
            Console.WriteLine("Rook on a1");
            Console.WriteLine("Move {0}{1} - {2}", 'b', 4, r.Move('b', 4));
            Console.WriteLine("Move {0}{1} - {2}", 'f', 2, r.Move('f', 2));
            Console.WriteLine("Move {0}{1} - {2}", 'b', 4, r.Move('c', 3));
            Console.WriteLine("Move {0}{1} - {2}", 'a', 8, r.Move('a', 8));
            Console.WriteLine("Move {0}{1} - {2}", 'b', 8, r.Move('b', 8));
            Console.WriteLine("Move {0}{1} - {2}", 'b', 0, r.Move('b', 0));

            Knight k = new Knight('d', 4);
            Console.WriteLine("Knight on d4");
            Console.WriteLine("Move {0}{1} - {2}", 'e', 6, k.Move('e', 6));
            Console.WriteLine("Move {0}{1} - {2}", 'f', 5, k.Move('f', 5));
            Console.WriteLine("Move {0}{1} - {2}", 'b', 3, k.Move('b', 3));
            Console.WriteLine("Move {0}{1} - {2}", 'b', 5, k.Move('b', 5));
            Console.WriteLine("Move {0}{1} - {2}", 'c', 2, k.Move('c', 2));
            Console.WriteLine("Move {0}{1} - {2}", 'b', 0, k.Move('b', 0));

            Bishop b = new Bishop('d', 4);
            Console.WriteLine("Bishop on d4");
            Console.WriteLine("Move {0}{1} - {2}", 'c', 3, b.Move('c', 3));
            Console.WriteLine("Move {0}{1} - {2}", 'a', 1, b.Move('a', 1));
            Console.WriteLine("Move {0}{1} - {2}", 'b', 3, b.Move('b', 3));
            Console.WriteLine("Move {0}{1} - {2}", 'b', 5, b.Move('b', 5));
            Console.WriteLine("Move {0}{1} - {2}", 'c', 2, b.Move('c', 2));
            Console.WriteLine("Move {0}{1} - {2}", 'a', 8, b.Move('a', 8));

            Queen q = new Queen('d', 4);
            Console.WriteLine("Queen on d4");
            Console.WriteLine("Move {0}{1} - {2}", 'c', 3, q.Move('c', 3));
            Console.WriteLine("Move {0}{1} - {2}", 'a', 1, q.Move('a', 1));
            Console.WriteLine("Move {0}{1} - {2}", 'b', 3, q.Move('b', 3));
            Console.WriteLine("Move {0}{1} - {2}", 'b', 5, q.Move('b', 5));
            Console.WriteLine("Move {0}{1} - {2}", 'c', 2, q.Move('c', 2));
            Console.WriteLine("Move {0}{1} - {2}", 'd', 8, q.Move('d', 8));

            King kg = new King('h', 1);
            Console.WriteLine("King on h1");
            Console.WriteLine("Move {0}{1} - {2}", 'g', 2, kg.Move('g', 2));
            Console.WriteLine("Move {0}{1} - {2}", 'g', 1, kg.Move('g', 1));
            Console.WriteLine("Move {0}{1} - {2}", 'c', 4, kg.Move('c', 4));
            Console.WriteLine("Move {0}{1} - {2}", 'd', 5, kg.Move('d', 5));
            Console.WriteLine("Move {0}{1} - {2}", 'd', 3, kg.Move('d', 3));
            Console.WriteLine("Move {0}{1} - {2}", 'e', 5, kg.Move('e', 5));
            Console.WriteLine("Move {0}{1} - {2}", 'e', 4, kg.Move('e', 4));
            Console.WriteLine("Move {0}{1} - {2}", 'e', 3, kg.Move('e', 3));
        }

        public class Figure
        {
            public string Name { get; set; }
            public int[,] Chessboard = new int[2, 8] { { 1, 2, 3, 4, 5, 6, 7, 8 }, {1, 2, 3, 4, 5, 6, 7, 8 } };
            public int[,] Coord = new int[2, 1];
            public Figure(string name, char c, int n )
            {
                Name = name;
                Coord[0, 0] = char.ToLower(c) - 'a' + 1;
                Coord[1, 0] = n;
                foreach (var s in Coord)
                {
                    if (s < 1 || s > 8)
                    throw new Exception("The figure is out of Chessboard");
                }
            }

            public virtual bool Move(char a, int k)
            {
                int x = char.ToLower(a) - 'a' + 1;
                return (x >= 1 && x <=8 && k >= 1 && k <=8);
            }
        }

        public class Rook : Figure
        {
            public Rook(string name, char c, int i): this(c, i) 
            {
                
            }
            public Rook(char c, int i) : base("Rook", c, i)
            {
                
            }
            public override bool Move(char a, int k)
            {
                if (!base.Move(a, k))
                    return false;
                int x = char.ToLower(a) - 'a' + 1;
                int c = Coord[0, 0]; // letter 
                int n = Coord[1, 0];
                return (x == c && k != n) || (x != c && k == n);
            }
        }

    public class Knight : Figure
    {
        public Knight(string name, char c, int i) : this(c, i)
        {

        }
        public Knight(char c, int i) : base("Knight", c, i)
        {

        }
        public override bool Move(char a, int k)
        {
            if (!base.Move(a, k))
                return false;
            int x = char.ToLower(a) - 'a' + 1;
            int c = Coord[0, 0]; // letter 
            int n = Coord[1, 0];
            return ((x == (c + 2) || x == (c - 2)) && (k == (n + 1) || k == (n - 1))) || ((k == (n + 2) || k == (n - 2)) && (x == (c + 1) || x == (c - 1)));
        }
    }

        public class Bishop : Figure
        {
            public Bishop(string name, char c, int i) : this(c, i)
            {

            }
            public Bishop(char c, int i) : base("Bishop", c, i)
            {

            }
            public override bool Move(char a, int k)
            {
                if (!base.Move(a, k))
                    return false;
                int x = char.ToLower(a) - 'a' + 1;
                int c = Coord[0, 0]; // letter 
                int step = Math.Abs(c - x);
                int n = Coord[1, 0];
                return Math.Abs(k - n) == step || (k + n) == step;
            }
        }
        public class Queen : Figure
        {
            public Queen(string name, char c, int i) : this(c, i)
            {

            }
            public Queen(char c, int i) : base("Queen", c, i)
            {

            }
            public override bool Move(char a, int k)
            {
                if (!base.Move(a, k))
                    return false;
                int x = char.ToLower(a) - 'a' + 1;
                int c = Coord[0, 0]; // letter 
                int step = Math.Abs(c - x);
                int n = Coord[1, 0];
                return (Math.Abs(k - n) == step || (k + n) == step) || ((x == c && k != n) || (x != c && k == n));
            }
        }

        public class King : Figure
        {
            public King(string name, char c, int i) : this(c, i)
            {

            }
            public King(char c, int i) : base("King", c, i)
            {

            }
            public override bool Move(char a, int k)
            {
                if (!base.Move(a, k))
                    return false;
                int x = char.ToLower(a) - 'a' + 1;
                int c = Coord[0, 0]; // letter 
                int step = Math.Abs(c - x);
                int n = Coord[1, 0];
                return ((c - x) == 0 && Math.Abs(n - k) == 1) || ((n - k) == 0 && Math.Abs(c - x) == 1) || (Math.Abs(c - x) == 1 && Math.Abs(n - k) == 1);            }
        }
    }
}
