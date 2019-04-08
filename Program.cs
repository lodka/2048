using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace barbars
{
    class Program
    {
        static int[,] board;
        static void Main(string[] args)
        {
            board = null;
            DrawBoard("Hello this is 2048 game.\nTo start a new game press n.\nIf you want to discover how to play press h.\nIf you want to quit press Esc.");
            while (true) Command();
        }
        static void Command()
        {
            if (Check())
            {
                DrawBoard("No more moves.\nPress n to start a new game or press Esc to quit.");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.B:
                        if (board == null)
                            DrawBoard("Hello this is 2048 game.\nTo start a new game press n.\nIf you want to discover how to play press h.\nIf you want to quit press Esc.");
                        else
                            DrawBoard();
                        break;
                    case ConsoleKey.H:
                        DrawBoard("Use arrow keys or WASD to move tiles to corresponding sides.\nTo start a new game press n.\nIf you want to quit press Esc.\nPress b to go back to previous menu.");
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;

                    case ConsoleKey.N:
                        NewGame(4);
                        GenNew();
                        DrawBoard("Started a new game.");
                        break;
                }
            }
            else
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.B:
                        if (board == null)
                            DrawBoard("Hello this is 2048 game.\nTo start a new game press n.\nIf you want to discover how to play press h.\nIf you want to quit press Esc.");
                        else
                            DrawBoard();
                        break;
                    case ConsoleKey.H:
                        DrawBoard("Use arrow keys or WASD to move tiles to corresponding sides.\nTo start a new game press n.\nIf you want to quit press Esc.\nPress b to go back to previous menu.");
                        break;
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        if (board != null)
                        {
                            MoveUp();
                            GenNew();
                            DrawBoard(
    @"         
            /|\
             |");
                        }
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        if (board != null)
                        {
                            MoveDown();
                            GenNew();
                            DrawBoard(
    @"
             |
            \|/
         ");
                        }
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        if (board != null)
                        {
                            MoveLeft();
                            GenNew();
                            DrawBoard(
     @"
           <———
            
         ");
                        }
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        if (board != null)
                        {
                            MoveRight();
                            GenNew();
                            DrawBoard(
    @"
           ———>
            
         ");
                        }
                        break;
                    case ConsoleKey.N:
                        NewGame(4);
                        GenNew();
                        DrawBoard("Started a new game.");
                        break;
                }

        }
        static void NewGame(int size)
        {
            board = new int[size, size];
        }
        static void GenNew()
        {
            int count = 0;
            Random rand = new Random();
            int x, y;
            int counter = 0;
            while (count != 2)
            {
                if (counter > 300) break;
                x = rand.Next(4);
                y = rand.Next(4);
                if (board[x, y] == 0)
                {
                    board[x, y] = 2;
                    count++;
                }
                counter++;
            }
        }
        static void MoveUp()
        {
            int i = 1;
            for (int y = 1; y < board.GetLength(1); ++y)
            {
                for (int x = 0; x < board.GetLength(0); ++x)
                {
                    i = 1;
                    while (y - i >= 0)
                    {
                        if (board[x, y - i] != 0)
                        {
                            if (board[x, y] == board[x, y - i])
                            {
                                board[x, y - i] *= 2;
                                board[x, y] = 0;
                            }
                            else if (i > 1)
                            {
                                board[x, y - i + 1] = board[x, y];
                                board[x, y] = 0;
                            }
                            break;
                        }
                        else if (y - i == 0)
                        {
                            board[x, y - i] = board[x, y];
                            board[x, y] = 0;
                        }
                        i++;
                    }
                }
            }
        }
        static void MoveDown()
        {
            int i = 1;
            for (int y = board.GetLength(1) - 2; y >= 0; --y)
            {
                for (int x = 0; x < board.GetLength(0); ++x)
                {
                    i = 1;
                    while (y + i <= board.GetLength(1) - 1)
                    {
                        if (board[x, y + i] != 0)
                        {
                            if (board[x, y] == board[x, y + i])
                            {
                                board[x, y + i] *= 2;
                                board[x, y] = 0;
                            }
                            else if (i > 1)
                            {
                                board[x, y + i - 1] = board[x, y];
                                board[x, y] = 0;
                            }
                            break;
                        }
                        else if (y + i == board.GetLength(1) - 1)
                        {
                            board[x, y + i] = board[x, y];
                            board[x, y] = 0;
                        }
                        i++;
                    }
                }
            }
        }
        static void MoveLeft()
        {
            int i = 1;
            for (int x = 1; x < board.GetLength(0); ++x)
            {
                for (int y = 0; y < board.GetLength(1); ++y)
                {
                    i = 1;
                    while (x - i >= 0)
                    {
                        if (board[x - i, y] != 0)
                        {
                            if (board[x, y] == board[x - i, y])
                            {
                                board[x - i, y] *= 2;
                                board[x, y] = 0;
                            }
                            else if (i > 1)
                            {
                                board[x - i + 1, y] = board[x, y];
                                board[x, y] = 0;
                            }
                            break;
                        }
                        else if (x - i == 0)
                        {
                            board[x - i, y] = board[x, y];
                            board[x, y] = 0;
                        }
                        i++;
                    }
                }
            }
        }
        static void MoveRight()
        {
            int i = 1;
            for (int x = board.GetLength(0) - 2; x >= 0; --x)
            {
                for (int y = 0; y < board.GetLength(1); ++y)
                {
                    i = 1;
                    while (x + i <= board.GetLength(0) - 1)
                    {
                        if (board[x + i, y] != 0)
                        {
                            if (board[x, y] == board[x + i, y])
                            {
                                board[x + i, y] *= 2;
                                board[x, y] = 0;
                            }
                            else if (i > 1)
                            {
                                board[x + i - 1, y] = board[x, y];
                                board[x, y] = 0;
                            }
                            break;
                        }
                        else if (x + i == board.GetLength(0) - 1)
                        {
                            board[x + i, y] = board[x, y];
                            board[x, y] = 0;
                        }
                        i++;
                    }
                }
            }
        }
        static bool Check2048(int val)
        {
            for (int x = 0; x < board.GetLength(0); ++x)
            {
                for (int y = 0; y < board.GetLength(1); ++y)
                {
                    if (board[x, y] == val) return true;
                }
            }
            return false;
        }
        static bool Check()
        {
            if (board == null) return false;
            for (int x = 0; x < board.GetLength(0); ++x)
            {
                for (int y = 0; y < board.GetLength(1); ++y)
                {
                    if (x + 1 < board.GetLength(0) && (board[x + 1, y] == board[x, y] || board[x + 1, y] == 0)) return false;
                    if (y + 1 < board.GetLength(1) && (board[x, y + 1] == board[x, y] || board[x, y + 1] == 0)) return false;
                    if (x - 1 >= 0 && (board[x - 1, y] == board[x, y] || board[x - 1, y] == 0)) return false;
                    if (y - 1 >= 0 && (board[x, y - 1] == board[x, y] || board[x, y - 1] == 0)) return false;
                }
            }
            return true;
        }
        static void DrawBoard(string query)
        {
            DrawBoard();
            Console.WriteLine(query);
        }
        static void DrawBoard()
        {
            int num = 128;
            Console.Clear();
            string outstr = @"  ___   ___  _  _   ___  
 |__ \ / _ \| || | / _ \ 
    ) | | | | || || (_) |
   / /| | | |__   _> _ < 
  / /_| |_| |  | || (_) |
 |____|\___/   |_| \___/ 

";
            if (board != null)
            {
                for (int y = 0; y < board.GetLength(1); ++y)
                {
                    outstr += "-----------------------------\n| ";
                    for (int x = 0; x < board.GetLength(0); ++x)
                    {
                        if (board[x, y] != 0)
                            if (board[x, y] > 9 && board[x, y] <= 99)
                                outstr += " " + board[x, y] + "  | ";
                            else if (board[x, y] > 99 && board[x, y] <= 999)
                                outstr += board[x, y] + "  | ";
                            else if (board[x, y] > 999)
                                outstr += board[x, y] + " | ";
                            else outstr += "  " + board[x, y] + "  | ";
                        else outstr += "     | ";
                    }
                    outstr += "\n";
                }
                outstr += "-----------------------------";
                if (Check2048(num))
                {
                    outstr += "\nGood Job you get " + num + "\n";
                }
            }

            Console.WriteLine(outstr);
        }

    }


}
