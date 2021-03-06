using System;
public class Program{

    private static int x = 0, y = 0;

    public static void makeMoveRow(){
		try{	
			do{
				Console.WriteLine("Row: ");
				x = int.Parse(Console.ReadLine()) - 1;			
			}while (x > 2 || x < 0);
		}catch (System.FormatException error){
			Console.WriteLine("Digite apenas valores aceitos. (1, 2 ou 3)");
			makeMoveRow();
		}
    }
	
	public static void makeMoveColumn(){
	try{
		do{
			Console.WriteLine("Column: ");
			y = int.Parse(Console.ReadLine()) - 1;
		}while (y > 2 || y < 0);
	}catch (System.FormatException error){
			Console.WriteLine("Digite apenas valores aceitos. (1, 2 ou 3)");
			makeMoveColumn();
		}
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
        
        for(int i = 0 ; i < 3 ; i++){
            if(field[i,0] == " x " && field[i,1] == " x " && field[i,2] == " x "){
                return true;
            } else if (field[i,0] == " o " && field[i,1] == " o " && field[i,2] == " o "){
                return true;
            } else if(field[0,i] == " x " && field[1,i] == " x " && field[2,i] == " x "){
                return true;
            } else if (field[0,i] == " o " && field[1,i] == " o " && field[2,i] == " o "){
                return true;
            }
        }

       
        if(field[0,0] == " x " && field[1,1] == " x " && field[2,2] == " x "){
            return true;
        } else if (field[0,0] == " o " && field[1,1] == " o " && field[2,2] == " o "){
            return true;
        }
		
		if(field[0,2] == " x " && field[1,1] == " x " && field[2,0] == " x "){
            return true;
        } else if (field[0,2] == " o " && field[1,1] == " o " && field[2,0] == " o "){
            return true;
        }
        return false;
    }

    public static Boolean blockedPlay(string[,] field){
        if (field[x, y] == " x " || field[x, y] == " o ")
            return true;
        else
            return false;
    }

    public static void Main(){

        string[,] field = new string[3, 3];
        int count = 0;
        string currentPlayer;

        for (int i = 0; i < 3; i++){
            for (int j = 0; j < 3; j++){
                field[i, j] = " - ";
            }
        }

        showHash(field);

        do{
            if (count % 2 == 0){
                currentPlayer = "Player x";
                Console.WriteLine(currentPlayer+":");
                makeMoveRow();
				makeMoveColumn();

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
                currentPlayer = "Player o";
                Console.WriteLine(currentPlayer+":");
                makeMoveRow();
				makeMoveColumn();

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
                 Console.WriteLine("Congratulations '"+currentPlayer+"', you won!");
                break;
            }
        } while (count < 9);
        if(count == 9)
            Console.WriteLine("Hash!");
    }
}