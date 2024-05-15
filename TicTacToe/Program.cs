namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] board = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" }; // Definiranje inicijalnog stanja ploče s brojevima od 1 do 9, koji predstavljaju slobodna polja.
            int playerX;
            int playerO; // Inicijalizacija varijabli playerX i playerO koje će sadržavati odabrane pozicije igrača X i O.
            bool winCheck = false; // Postavljanje početnih vrijednosti za provjeru pobjednika (winCheck) i prikazivanje prazne ploče na početku igre pomoću funkcije TicTacBoard.
            TicTacBoard(board);
            int i = 1;
            while (!winCheck && i < board.Length) // Glavna petlja koja se izvršava dok nema pobjednika i dok ima slobodnih mjesta na ploči.
            {
                var isValidXMove = false;

                while (!isValidXMove)
                {
                    //PLAYER X
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("\nPLAYER X IS ON THE MOVE: ");
                    Console.WriteLine("---------------------------");
                    playerX = int.Parse(Console.ReadLine());

                    if (board[playerX] == "X" || board[playerX] == "O")
                    {
                        Console.WriteLine($"Field {playerX} is already occupied. Try again!");
                    }
                    else
                    {
                        board[playerX] = "X";
                        isValidXMove = true;
                    }
                }

                TicTacBoard(board); // Poziv metode za prikaz tabele koja se koristi se za ispis trenutnog stanja ploče na konzoli.
                winCheck = CheckWinner(board); // Poziv metode koja provjera pobjednika nakon poteza igrača X

                if (winCheck) // Ako je igrač X pobijedio, ispisuje se poruka i prekida se igra
                {
                    Console.WriteLine("-----------------");
                    Console.WriteLine("Player X is Win! ");
                    Console.WriteLine("-----------------");
                    break;
                }

                if (i + 1 == board.Length) // Ako su sva polja popunjena, prekida se igra
                {
                    break;
                }

                //PLAYER O
                var isValidOMove = false;

                while (!isValidOMove)
                {
                    //PLAYER X
                    Console.WriteLine("---------------------------");
                    Console.WriteLine("\nPLAYER O IS ON THE MOVE: ");
                    Console.WriteLine("---------------------------");
                    playerO = int.Parse(Console.ReadLine());

                    if (board[playerO] == "X" || board[playerO] == "O")
                    {
                        Console.WriteLine($"Field {playerO} is already occupied. Try again!");
                    }
                    else
                    {
                        board[playerO] = "O";
                        isValidOMove = true;
                    }
                }

                TicTacBoard(board); // Poziv metode za prikaz tabele koja se koristi se za ispis trenutnog stanja ploče na konzoli.
                winCheck = CheckWinner(board); // Poziv metode koja provjera pobjednika nakon poteza igrača O

                if (winCheck)
                {
                    Console.WriteLine("-----------------");
                    Console.WriteLine("Player O is Win! ");
                    Console.WriteLine("-----------------");
                    break;
                }
                i += 2;  // Povećavanje brojača i za nastavak sljedećeg ciklusa
                
            }

            if (winCheck == false) // Ispis poruke ako nema pobjednika
            {
                Console.WriteLine("-----------------");
                Console.WriteLine("NO GAME WINNER! ");
                Console.WriteLine("-----------------");
            }
        }

        static void TicTacBoard(string[] arr) // Funkcija TicTacBoard koristi se za ispis trenutnog stanja ploče na konzoli.
        {
            // ... (ispisuje trenutno stanje ploče)
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[1], arr[2], arr[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[4], arr[5], arr[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", arr[7], arr[8], arr[9]);
            Console.WriteLine("     |     |      ");
        }

        static bool CheckWinner(string[] board) // Funkcija CheckWinner provjerava pobjednika na temelju trenutnog stanja ploče.
        {
            // ... (provjera pobjednika prema pravilima igre)
            //horizontal
            if ((board[1] != null && board[2] != null && board[3] != null && board[1] == board[2] && board[2] == board[3]) ||
                (board[4] != null && board[5] != null && board[6] != null && board[4] == board[5] && board[5] == board[6]) ||
                (board[7] != null && board[8] != null && board[9] != null && board[7] == board[8] && board[8] == board[9]))
            {
                return true;
            }

            //diagonal
            else if ((board[1] != null && board[5] != null && board[9] != null && board[1] == board[5] && board[5] == board[9]) ||
                     (board[3] != null && board[5] != null && board[7] != null && board[3] == board[5] && board[5] == board[7]))
            {
                return true;
            }

            //vertical
            else if ((board[1] != null && board[4] != null && board[7] != null && board[1] == board[4] && board[4] == board[7]) ||
                     (board[2] != null && board[5] != null && board[8] != null && board[2] == board[5] && board[5] == board[8]) ||
                     (board[3] != null && board[6] != null && board[9] != null && board[3] == board[6] && board[6] == board[9]))
            {
                return true;
            }
            return false;

        }
        
    }
}