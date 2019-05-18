using System;

public class Program{

    private static int x = 0, y = 0;

    public static void makeMove(){
        Console.WriteLine("Row: ");
        x = int.Parse(Console.ReadLine()) - 1;
        Console.WriteLine("Column: ");
        y = int.Parse(Console.ReadLine()) - 1;
    }

    public static void showHash(string[,] field){
        Console.WriteLine("Hash Game!");
        for (int i = 0; i < 3; i++){
            for (int j = 0; j < 3; j++){
                Console.Write(field[i, j]);
            }
            Console.Write('\n');
        }
    }

    public static Boolean hasWinner(string[,] field){
        int a = 0;
        int b = 0;
        int da = 0;
        int db = 0;
        for (int i = 0; i < 3; i++){
            for (int j = 0; j < 3; j++){

                if (field[i, j] == " x "){
                    a++;
                }
                else if (field[i, j] == " o "){
                    b++;
                }

                if (i == j) {
                    if (field[i, j] == " x "){
                        da++;
                    }
                    else if (field[i, j] == " o "){
                        db++;
                    }
                }
            }

            if (a == 3){
                Console.WriteLine("Congratulations 'player x', you won!");
                return true;
            }
            else if (b == 3){
                Console.WriteLine("Congratulations 'player y' , you won!");
                return true;
            }
            else{
                a = 0;
                b = 0;
            }
        }
        if (da == 3){
            Console.WriteLine("Congratulations 'player x', you won!");
            return true;
        }
        else if (db == 3){
            Console.WriteLine("Congratulations 'player y', you won!");
            return true;
        }

        return false;
    }

    public static Boolean blockedPlay(string[,] field){
        if (field[x, y] == "x" || field[x, y] == "y")
            return true;
        else
            return false;
    }

    public static void Main(){

        string[,] field = new string[3, 3];
        int count = 0;

        for (int i = 0; i < 3; i++){
            for (int j = 0; j < 3; j++){
                field[i, j] = " - ";
            }
        }

        showHash(field);

        do{
            if (count % 2 == 0){
                Console.WriteLine("Player x:");
                makeMove();

                if (blockedPlay(field)){
                    Console.WriteLine("Invalid play, position already filled.");
                }
                else{
                    field[x, y] = " x ";
                    count++;
                    Console.Clear();
                    showHash(field);
                }
            }
            else{
                Console.WriteLine("Player o:");
                makeMove();

                if (blockedPlay(field)){
                    Console.WriteLine("Invalid play, position already filled.");
                }
                else{
                    field[x, y] = " o ";
                    count++;
                    Console.Clear();
                    showHash(field);
                }
            }
            if (hasWinner(field)){
                break;
            }
        } while (count < 9);
    }
}