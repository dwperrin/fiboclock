using System;

namespace fiboclock
{
  class Program
  {
    private const int CLOCK_PIXELS = 5;
    private static byte[] bits = new byte[CLOCK_PIXELS];
    private static Random rand = new Random();
    private static int oldHours;
    private static int oldMinutes;

    private static ConsoleColor[] colours = new ConsoleColor[4]
    {
      ConsoleColor.Black,  // of
      ConsoleColor.Red,    // houre
      ConsoleColor.DarkGreen,  // minutes
      ConsoleColor.Blue     // both
    };

    public static void Main(string[] args)
    {
      while (true)
      {
        DisplayCurrentTime();
      }
    }

    private static void DisplayCurrentTime()
    {
      var now = DateTime.Now;
      showTime(now.Hour % 12, now.Minute);
    }

    private static void showTime(int hours, int minutes)
    {
      if (oldHours == hours && oldMinutes / 5 == minutes / 5)
        return;

      oldHours = hours;
      oldMinutes = minutes;

      for (int i = 0; i < CLOCK_PIXELS; i++)
        bits[i] = 0;

      setBits(hours, 0x01);
      setBits(minutes / 5, 0x02);

      Console.SetCursorPosition(0, Console.CursorTop);
      for (int i = 0; i < CLOCK_PIXELS; i++)
      {
        Console.BackgroundColor = colours[bits[i]];
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(getFibonacci(i));
        Console.BackgroundColor = ConsoleColor.Black;
        Console.Write(" ");
      }
    }

    private static int getFibonacci(int index)
    {
      switch (index)
      {
        case 0:
          return 1;
        case 1:
          return 1;
        case 2:
          return 2;
        case 3:
          return 3;
        case 4:
          return 5;
      }
      throw new Exception();
    }

    private static void setBits(int value, byte offset)
    {
      switch (value)
      {
        case 1:
          switch (rand.Next(2))
          {
            case 0:
              bits[0] |= offset;
              break;
            case 1:
              bits[1] |= offset;
              break;
          }
          break;
        case 2:
          switch (rand.Next(2))
          {
            case 0:
              bits[2] |= offset;
              break;
            case 1:
              bits[0] |= offset;
              bits[1] |= offset;
              break;
          }
          break;
        case 3:
          switch (rand.Next(3))
          {
            case 0:
              bits[3] |= offset;
              break;
            case 1:
              bits[0] |= offset;
              bits[2] |= offset;
              break;
            case 2:
              bits[1] |= offset;
              bits[2] |= offset;
              break;
          }
          break;
        case 4:
          switch (rand.Next(3))
          {
            case 0:
              bits[0] |= offset;
              bits[3] |= offset;
              break;
            case 1:
              bits[1] |= offset;
              bits[3] |= offset;
              break;
            case 2:
              bits[0] |= offset;
              bits[1] |= offset;
              bits[2] |= offset;
              break;
          }
          break;
        case 5:
          switch (rand.Next(3))
          {
            case 0:
              bits[4] |= offset;
              break;
            case 1:
              bits[2] |= offset;
              bits[3] |= offset;
              break;
            case 2:
              bits[0] |= offset;
              bits[1] |= offset;
              bits[3] |= offset;
              break;
          }
          break;
        case 6:
          switch (rand.Next(4))
          {
            case 0:
              bits[0] |= offset;
              bits[4] |= offset;
              break;
            case 1:
              bits[1] |= offset;
              bits[4] |= offset;
              break;
            case 2:
              bits[0] |= offset;
              bits[2] |= offset;
              bits[3] |= offset;
              break;
            case 3:
              bits[1] |= offset;
              bits[2] |= offset;
              bits[3] |= offset;
              break;
          }
          break;
        case 7:
          switch (rand.Next(3))
          {
            case 0:
              bits[2] |= offset;
              bits[4] |= offset;
              break;
            case 1:
              bits[0] |= offset;
              bits[1] |= offset;
              bits[4] |= offset;
              break;
            case 2:
              bits[0] |= offset;
              bits[1] |= offset;
              bits[2] |= offset;
              bits[3] |= offset;
              break;
          }
          break;
        case 8:
          switch (rand.Next(3))
          {
            case 0:
              bits[3] |= offset;
              bits[4] |= offset;
              break;
            case 1:
              bits[0] |= offset;
              bits[2] |= offset;
              bits[4] |= offset;
              break;
            case 2:
              bits[1] |= offset;
              bits[2] |= offset;
              bits[4] |= offset;
              break;
          }
          break;
        case 9:
          switch (rand.Next(2))
          {
            case 0:
              bits[0] |= offset;
              bits[3] |= offset;
              bits[4] |= offset;
              break;
            case 1:
              bits[1] |= offset;
              bits[3] |= offset;
              bits[4] |= offset;
              break;
          }
          break;
        case 10:
          switch (rand.Next(2))
          {
            case 0:
              bits[2] |= offset;
              bits[3] |= offset;
              bits[4] |= offset;
              break;
            case 1:
              bits[0] |= offset;
              bits[1] |= offset;
              bits[3] |= offset;
              bits[4] |= offset;
              break;
          }
          break;
        case 11:
          switch (rand.Next(2))
          {
            case 0:
              bits[0] |= offset;
              bits[2] |= offset;
              bits[3] |= offset;
              bits[4] |= offset;
              break;
            case 1:
              bits[1] |= offset;
              bits[2] |= offset;
              bits[3] |= offset;
              bits[4] |= offset;
              break;
          }

          break;
        case 12:
          bits[0] |= offset;
          bits[1] |= offset;
          bits[2] |= offset;
          bits[3] |= offset;
          bits[4] |= offset;

          break;
      }
    }
  }
}
