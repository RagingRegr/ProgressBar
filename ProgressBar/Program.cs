using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;

namespace ProgressBar3000
{
	internal class Program
	{
		public const int steps = 50;
		public const int wait = 100;
		public const string firstchar = "\u2591";
		public const string secondchar = "\u2592";
		public const string thirdchar = "\u2593";
		public const int maxstep = 25;
		public const int maxwait = 500;
		static void Main(string[] args)
		{
			//if(i<x/3 = zelena) if (i>x/3 && i<x/3+x/3= jina barva) else barvika
			Settings();
			ProgressBar1();
			Console.WriteLine();
			PrintProgress2();
		}

		private static void PrintProgress2()
		{
			for (var i = 0; i < steps; i++)
			{
				Console.CursorLeft = i;
				for (var j = 0; j <= 2; j++)
				{
					Colorifier(i,steps);
					if (j == 0)
					{
						Console.Write(firstchar);
						Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
					}
					else if (j == 1)
					{
						Console.Write(secondchar);
						Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
					}
					else
					{
						Console.Write(thirdchar);
						if (i != steps - 1)
						{
							Console.SetCursorPosition(Console.CursorLeft + 1, Console.CursorTop);
						}
					}
					Thread.Sleep(wait);
				}
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.Write($"{i+1}/{steps}");
			}
		}
		#region FirstType
		private static void PrintProgress1(int randstep, int randwait)
		{
			for (var i = 0; i < randstep; i++)
			{
				Colorifier(i,randstep);
				Console.CursorLeft = i;
				Console.Write(thirdchar);
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.Write($"{i+1}/{randstep}");
				Thread.Sleep(randwait);
			}
		}
		private static void ProgressBar1()
		{
			var randstep = Generator(maxstep);
			var randwait = Generator(maxwait);
			PrintProgress1(randstep, randwait);
		}
		private static int Generator(int val)
		{
			Random rnd = new Random();
			var number = rnd.Next(val);
			return number;
		}
		#endregion

		private static void Colorifier(int i,int val)
		{
			if (i <= ((double)val / 3))
			{
				Console.ForegroundColor = ConsoleColor.Red;
			}
			if ((i > ((double)val / 3)) && (i <= ((double)val /3+ (double)val /3)))
			{
				Console.ForegroundColor = ConsoleColor.DarkYellow;
			}
			else
			{
				Console.ForegroundColor = ConsoleColor.Green;
			}
		}
		private static void Settings()
		{
			Console.OutputEncoding = Encoding.UTF8;
			Console.CursorVisible = false;
		}
	}
}