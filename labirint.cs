using System;
class LabyrinthSolver
{
    static int[] dx = { -1, 0, 1, 0 }; // yo'nalish vektorlari
    static int[] dy = { 0, 1, 0, -1 };

    static bool Search(int[,] labyrinth, int x, int y)
    {
        int n = labyrinth.GetLength(0);
        int m = labyrinth.GetLength(1);

        if (x < 0 || x >= n || y < 0 || y >= m || labyrinth[x, y] == 1)
        {
            return false; // chegara yoki to`siqdan tashqari
        }

        if (labyrinth[x, y] == 8)
        {
            return true; // yurilgan
        }

        labyrinth[x, y] = 8; // yurilgan deb belgilash

        for (int i = 0; i < 4; i++)
        { // 4 ta qo`shnilarni tekshirish
            if (Search(labyrinth, x + dx[i], y + dy[i]))
            {
                return true; // topildi
            }
        }

        labyrinth[x, y] = 0; // belgini bekor qilish

        return false; // yo`l yo`q
    }

    static void Main()
    {
        int[,] labyrinth = {
            {0, 0, 1, 1, 1},
            {1, 0, 1, 0, 0},
            {0, 0, 0, 0, 1},
            {1, 1, 1, 0, 0},
            {1, 1, 1, 0, 1},
            {1, 1, 1, 0, 0},
        };

        int startX = 0;
        int startY = 0;
        int endX = labyrinth.GetLength(0) - 1;
        int endY = labyrinth.GetLength(1) - 1;

        if (Search(labyrinth, startX, startY))
        {
            Console.WriteLine("Yo`l topildi");
        }
        else
        {
            Console.WriteLine("Yo`l topilmadi");
        }

        // labirintni sakkizta belgilangan yo'l bilan chop etish
        for (int i = 0; i < labyrinth.GetLength(0); i++)
        {
            for (int j = 0; j < labyrinth.GetLength(1); j++)
            {
                Console.Write("{0} ", labyrinth[i, j]);
            }
            Console.WriteLine();
        }
    }
}