using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace multimedia
{
    class Program
    {
        //Método que apresenta o menu de escolha de operações
        /// <summary>
        /// Menu Function.
        /// This function print the menu options in a console application command line
        /// </summary>
        /// <returns></returns>
        static int menu()
        {
            string escolha; //variable that holds the option selected by the user
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("\n***************************************************************\n\n Select an option:\n\n***************************************************************\n\n 1 - Add a new elment.\n 2 - Remove an element from the library.\n 3 - Edit an element.\n 4 - Add a rental.\n 5 - Change a rental to returned status.\n 6 - View database.\n 7 - Add category.\n 8 - View rentals that weren't returned yet.\n 9 - Save database\n10 - Quit application.\n\n***************************************************************\n\n ->");
                Console.ResetColor();
                escolha = Console.ReadLine(); //save the option to the variable
                if (escolha == "6") //se a escolha for consultar os dados, então apresenta um submenu
                {
                    do
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write("\n Select an option:\n\n***************************************************************\n\n1 - List all elements\n2 - List all categories\n3 - List rentals\n\n***************************************************************\n\n4 - List Movies\n5 - List Music\n6 - List Pictures\n\n***************************************************************\n\n7 - List Movies by category\n8 - List Music by category\n9 - List Pictures by category\n\n***************************************************************\n\n ->");
                        Console.ResetColor();
                        escolha = Console.ReadLine();
                        //As an alternative you may use a switch satement here instead of the if else statement
                        if (escolha == "1")
                        {
                            return 11;
                        }
                        else if (escolha == "2")
                        {
                            return 12;
                        }
                        else if (escolha == "3")
                        {
                            return 13;
                        }
                        else if (escolha == "4")
                        {
                            return 14;
                        }
                        else if (escolha == "5")
                        {
                            return 15;
                        }
                        else if (escolha == "6")
                        {
                            return 16;
                        }
                        else if (escolha == "7")
                        {
                            return 17;
                        }
                        else if (escolha == "8")
                        {
                            return 18;
                        }
                        else if (escolha == "9")
                        {
                            return 19;
                        }
                    } while (escolha != "1" & escolha != "2" & escolha != "3" & escolha != "4" & escolha != "5" & escolha != "6" & escolha != "7" & escolha != "8" & escolha != "9");
                }
                else if (escolha == "10")
                {
                    do
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\nAre you sure you want to quit? \n\n");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.ResetColor();

                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\n\n\n  *******************************************************************");
                        Console.WriteLine("  *******************************************************************");
                        Console.WriteLine("  ***                                                             ***");
                        Console.WriteLine("  ***   Are you sure you want to quit?                            ***");
                        Console.WriteLine("  ***                                                             ***");
                        Console.Write("  ***   ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("If you quit now changes will be lost");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write("                      ***\n");
                        Console.WriteLine("  ***                                                             ***");
                        Console.WriteLine("  ***                                       1-Quit   2-Cancel     ***");
                        Console.WriteLine("  ***                                                             ***");
                        Console.WriteLine("  *******************************************************************");
                        Console.WriteLine("  *******************************************************************");
                        Console.ResetColor();
                        escolha = Console.ReadLine();
                        if (escolha == "1")
                        {
                            return 666;
                        }
                        else if
                            (escolha == "2")
                        {
                            return 10;
                        }

                    } while (escolha != "2" & escolha != "1");
                }
            }
            while (escolha != "1" & escolha != "2" & escolha != "3" & escolha != "4" & escolha != "5" & escolha != "6" & escolha != "7" & escolha != "8" & escolha != "9" & escolha != "10");
            return Convert.ToInt32(escolha);
        }

        //Os argumentos de array lists foram necessários para usar um método dentro do método usando apenas os conhecimentos aprendidos até à data
        /// <summary>
        /// Method/Function to add a new element. The application checks if the element already exists in the database and validates insertion.
        /// </summary>
        /// <param name="id_novo"></param>
        /// <param name="tipo">Type of element</param>
        /// <param name="n"></param>
        /// <param name="elementos_multimedia"></param>
        /// <param name="categorias"></param>
        /// <param name="emprestimos"></param>
        /// <param name="numero_de_emprestimos"></param>
        /// <returns></returns>
        static string[] adicelemento(int id_novo, int tipo, int n, ArrayList elementos_multimedia, ArrayList categorias, ArrayList emprestimos, int numero_de_emprestimos)
        {
            string[] elementadd = new string[n], emprestimos_state;
            int verificador, check_field_exists_in_elements, check_field_exists_in_categorias, final_check;
            if (tipo == 1)
            {
                elementadd[0] = Convert.ToString(id_novo);

                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\nName for the new element:\n");
                    Console.ResetColor();
                    elementadd[1] = Console.ReadLine();
                    check_field_exists_in_elements = verifica_id_elementos(elementadd[1], elementos_multimedia);
                    check_field_exists_in_categorias = verifica_id_elementos(elementadd[1], categorias);
                    verificador = veririfica_se_inteiro(elementadd[1]);
                    if ((check_field_exists_in_elements == 1 && verificador == 2) || (check_field_exists_in_categorias == 1 && verificador == 2))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n There is already an element with that name in the database. Please choose another name for the element");
                        Console.ResetColor();
                        final_check = 1;
                    }
                    else
                    {
                        final_check = 0;
                    }
                } while (verificador == 1 || final_check == 1 || elementadd[1] == "" || elementadd[1] == "Filme" || elementadd[1] == "filme" || elementadd[1] == "Música" || elementadd[1] == "música" || elementadd[1] == "musica" || elementadd[1] == "Musica" || elementadd[1] == "Fotografia" || elementadd[1] == "fotografia");

                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\nType of element: (1 - Filme (Movie), 2 - Música (Music), 3 - Fotografia (Picture))\n");
                    Console.ResetColor();
                    elementadd[2] = Console.ReadLine();

                    //Check if the option selected for the type of element validates.
                    if (elementadd[2] == "1")
                    {
                        elementadd[2] = "Filme";
                    }
                    else if (elementadd[2] == "2")
                    {
                        elementadd[2] = "Música";
                    }
                    else if (elementadd[2] == "3")
                    {
                        elementadd[2] = "Fotografia";
                    }
                } while (elementadd[2] != "Filme" && elementadd[2] != "Música" && elementadd[2] != "Fotografia");

                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\nInsert category name which the element belongs to..:\n");
                    Console.ResetColor();
                    elementadd[3] = Console.ReadLine();
                    check_field_exists_in_categorias = verifica_id_elementos(elementadd[3], categorias);
                    verificador = veririfica_se_inteiro(elementadd[3]);
                    if (check_field_exists_in_categorias == 0 && verificador == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nWARNING: The selected category doesn't exist. Please choose a valid category\n");
                        Console.ResetColor();
                    }
                } while (verificador == 1 || check_field_exists_in_categorias == 0 || elementadd[3] == "" || elementadd[3] == "Filme" || elementadd[3] == "filme" || elementadd[3] == "Música" || elementadd[3] == "música" || elementadd[3] == "musica" || elementadd[3] == "Musica" || elementadd[3] == "Fotografia" || elementadd[3] == "fotografia");

                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\nFile Path:\n");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nATTENTION: THE LOCALTION SHOULD BE FORMATTED LIKE THIS: C:\\users\\documents\\filmes\\\n");
                    Console.ResetColor();
                    elementadd[4] = Console.ReadLine();
                    verificador = veririfica_se_inteiro(elementadd[4]);
                } while (verificador == 1 || elementadd[4] == "");

                elementadd[4] = elementadd[4] + elementadd[1]; //Add the element name to the file path

                DateTime elementdate = DateTime.Now;
                elementadd[5] = Convert.ToString(elementdate);
                return elementadd;
            }
            else if (tipo == 2)
            {
                elementadd[0] = Convert.ToString(id_novo);

                do
                {
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\nInsert the element's ID to create a rental:\n");
                        Console.ResetColor();
                        elementadd[4] = Console.ReadLine();
                        verificador = veririfica_se_inteiro(elementadd[4]);
                        check_field_exists_in_elements = verifica_id_elementos(elementadd[4], elementos_multimedia); //check if element exists
                        if (check_field_exists_in_elements == 0 && verificador == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n That element ID doesn't exist!");
                            Console.ResetColor();
                        }
                        else if (check_field_exists_in_elements == 1 && verificador == 1)
                        {
                            //check if the element is already with active rental status
                            emprestimos_state = converter_arraylist_elementos(emprestimos);

                            for (int i = 0; i < numero_de_emprestimos * 5; i++) //Instead of using a product by 5 you may use a foreach cycle here
                            {
                                if (emprestimos_state[i] == "id-emprestimo-" + elementadd[4] && emprestimos_state[i - 1] == "Por Entregar")
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nYou cant rent this element as long as its status is already active as a rental \n\n");
                                    Console.ResetColor();
                                    verificador = 2; //cicle while must continue as long as this variable value is other than 0
                                }
                            }
                        }
                    } while (verificador == 2 || check_field_exists_in_elements == 0);
                    elementadd[4] = "movie-" + elementadd[4];

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\nName of the person or email contact of the rental:\n");
                    Console.ResetColor();
                    elementadd[1] = Console.ReadLine();
                    verificador = veririfica_se_inteiro(elementadd[1]);
                } while (verificador == 1 || elementadd[1] == "" || elementadd[1] == "Filme" || elementadd[1] == "filme" || elementadd[1] == "Música" || elementadd[1] == "música" || elementadd[1] == "musica" || elementadd[1] == "Musica" || elementadd[1] == "Fotografia" || elementadd[1] == "fotografia");
                DateTime elementdate = DateTime.Now;
                elementadd[2] = Convert.ToString(elementdate);
                elementadd[3] = "Por Entregar";
                return elementadd;
            }
            else if (tipo == 3)
            {
                elementadd[0] = Convert.ToString(id_novo);
                do
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\nCategory name");
                    Console.ResetColor();
                    elementadd[1] = Console.ReadLine();

                    check_field_exists_in_elements = verifica_id_elementos(elementadd[1], elementos_multimedia);
                    check_field_exists_in_categorias = verifica_id_elementos(elementadd[1], categorias);
                    verificador = veririfica_se_inteiro(elementadd[1]);

                    if ((check_field_exists_in_elements == 1 && verificador == 2) || (check_field_exists_in_categorias == 1 && verificador == 2))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nWARNING: There is already a database record with that name. Please do not try to duplicate records.\n");
                        Console.ResetColor();
                        final_check = 1;
                    }
                    else
                    {
                        final_check = 0;
                    }

                } while (verificador == 1 || final_check == 1 || elementadd[1] == "" || elementadd[1] == "Filme" || elementadd[1] == "filme" || elementadd[1] == "Música" || elementadd[1] == "música" || elementadd[1] == "musica" || elementadd[1] == "Musica" || elementadd[1] == "Fotografia" || elementadd[1] == "fotografia");
            }
            return elementadd;
        }

        /// <summary>
        /// Method that reads the database contained in a text file at the very beginning of the application
        /// </summary>
        /// <param name="numerodeelementos">Number of elements contained in the database</param>
        /// <param name="filepath">File Path of the text file containning the database</param>
        /// <param name="n">Number of fields for each element</param>
        /// <returns></returns>
        static string[,] lerelementos(int numerodeelementos, string filepath, int n)
        {
            string[,] elementsarray = new string[numerodeelementos, n]; //Array varible to store the contents of the database found in the text file "elements.txt"

            StreamReader leitura_2 = new StreamReader(filepath);
            //Skip the first 2 lines of the file because they contain non elements data.
            string resultado = leitura_2.ReadLine();    //read line 1
            resultado = leitura_2.ReadLine();           //read line 2

            //Cycle to add elements to the array variable that will store the data
            for (int i = 0; i < numerodeelementos; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    elementsarray[i, j] = leitura_2.ReadLine();
                }
            }
            leitura_2.Close();
            return elementsarray;
        }

        /// <summary>
        /// This Method saves the data back to the file.
        /// </summary>
        /// <param name="finaldestination">If this param is equal to 1 then this method will save the data</param>
        /// <param name="valor_inteiro_a_guardar_no_ficheiro"></param>
        /// <param name="filepath"></param>
        /// <param name="elementos_finais"></param>
        /// <param name="valor_inteiro_emprestimos"></param>
        /// <param name="filepath2"></param>
        /// <param name="emprestimos_finais"></param>
        /// <param name="id_elementos"></param>
        /// <param name="id_emprestimos"></param>
        /// <param name="id_categorias"></param>
        /// <param name="valor_inteiro_categorias"></param>
        /// <param name="filepath3"></param>
        /// <param name="categorias_finais"></param>
        /// <param name="filepath_backup_file"></param>
        /// <param name="numero_de_backups"></param>
        static void closeapplication(int finaldestination, int valor_inteiro_a_guardar_no_ficheiro, string filepath, string[] elementos_finais, int valor_inteiro_emprestimos, string filepath2, string[] emprestimos_finais, int id_elementos, int id_emprestimos, int id_categorias, int valor_inteiro_categorias, string filepath3, string[] categorias_finais, string filepath_backup_file, int numero_de_backups)
        {
            if (finaldestination == 1)
            {
                string directory = "backup_" + Convert.ToString(numero_de_backups) + "\\";

                string filepath_element = directory + "elements.txt";
                string filepath_categorias = directory + "categorias.txt";
                string filepath_emprestimos = directory + "emprestimos.txt";

                //DEVELOPER NOTE:
                //If you want to take this project further for your academic use i recommend you give it a try and use a SQL Database instead of writing to a text file or even make a serialized version of this project.
                //There is an example of serealization in another C# project I developed, be sure to check out..
                System.IO.Directory.CreateDirectory(directory);
                //Save data in file "index.txt"
                StreamWriter indexer = new StreamWriter(filepath_backup_file, false);
                indexer.WriteLine(numero_de_backups);
                indexer.WriteLine(numero_de_backups);
                indexer.Close();

                //Save data in file "elements.txt"
                FileStream f1 = new FileStream(directory + "elements.txt", FileMode.Create);
                f1.Close();

                StreamWriter texto_final = new StreamWriter(filepath_element, false);
                texto_final.WriteLine(valor_inteiro_a_guardar_no_ficheiro);         //save the number of elements in the file
                texto_final.WriteLine(id_elementos);                                //save quantity for id's created in the file

                //foearch cycle to save data in array variable argument "elementos_finais"
                foreach (string value in elementos_finais)
                {
                    texto_final.WriteLine(value);
                }
                texto_final.Close();

                //Save data in file "emprestimos.txt" - emprestimos stands for rentals
                FileStream f2 = new FileStream(directory + "emprestimos.txt", FileMode.Create);
                f2.Close();
                //StreamWriter texto_final_emprestimos = new StreamWriter(filepath2, false);
                StreamWriter texto_final_emprestimos = new StreamWriter(filepath_emprestimos, false);
                texto_final_emprestimos.WriteLine(valor_inteiro_emprestimos);
                texto_final_emprestimos.WriteLine(id_emprestimos);

                foreach (string value in emprestimos_finais)
                {
                    texto_final_emprestimos.WriteLine(value);
                }
                texto_final_emprestimos.Close();

                //Save data in file "categorias.txt"
                FileStream f3 = new FileStream(directory + "categorias.txt", FileMode.Create);
                f3.Close();
                //StreamWriter texto_final_categorias = new StreamWriter(filepath3, false);
                StreamWriter texto_final_categorias = new StreamWriter(filepath_categorias, false);
                texto_final_categorias.WriteLine(valor_inteiro_categorias);
                texto_final_categorias.WriteLine(id_categorias);

                foreach (string value in categorias_finais)
                {
                    texto_final_categorias.WriteLine(value);
                }
                texto_final_categorias.Close();
            }
        }

        /// <summary>
        /// Method that converts an ArrayList argument returning an array with elements contained in the ArrayList
        /// This is a support method used in the application a lot of times
        /// </summary>
        /// <param name="listafinal">ArrayList that will be converted to an array</param>
        /// <returns></returns>
        static string[] converter_arraylist_elementos(ArrayList listafinal)
        {
            string[] arrayfinal = listafinal.ToArray(typeof(string)) as string[];
            return arrayfinal;
        }

        /// <summary>
        /// Método que faz a leitura dos valores que contém a informação do numero de elementos e do último id adicionado no ficheiro dado através de um argumento
        /// </summary>
        /// <param name="filepath_leitura_inicial"></param>
        /// <returns></returns>
        static int[] leituradefiles(string filepath_leitura_inicial)
        {
            int[] resultado = new int[2];
            StreamReader leitura = new StreamReader(filepath_leitura_inicial);
            resultado[0] = Convert.ToInt32(leitura.ReadLine());
            resultado[1] = Convert.ToInt32(leitura.ReadLine());
            leitura.Close();
            return resultado;
        }

        /// <summary>
        /// This Method checks ofr existing elements in a category.
        /// </summary>
        /// <param name="listadeelementos">ArrayList with elements from the database</param>
        /// <param name="listadecategorias">Category type, 1- Movies, 2 - Music, 3 - Pictures</param>
        /// <param name="tipo"></param>
        static void verifica_elementos_na_categoria(ArrayList listadeelementos, ArrayList listadecategorias, int tipo)
        {
            string escolha_listagem;                            //PT: variável necessária dentro deste método para a listagem de elementos por categoria
            int contador999, contador888 = 0;                   //EN: variables used for counters | PT:contadores necessários para verificar se encontra os elementos pedidos nas opções de listagens
            string[] elemento_temp, categoria_temp;             //EN: temp arrays used in this method | PT: arrays temporáriros que são usados nas consultas dentro deste método

            //PT: valores conforme o tipo de elemento escolhido na pesquisa, identificado através do argumento do tipo int "n"
            string[] dados = new string[4];                     //EN: uni-dimensional array | PT:os valores serão guardados neste array uni-dimensional

            //check_field_exists_in_categorias = verifica_id_elementos(elementadd[1], categorias);

            if (tipo == 1)
            {
                dados[0] = "\nEN: Which Movie category do you want to list? | PT: Qual a categoria de Filmes que pretende listar?\n";
                dados[1] = "Filme";
                dados[2] = "\nEN: There isn't a category with that name | PT: Não existe nenhuma categoria com esse nome.\n";
                dados[3] = "\nA categoria existe!";
            }
            else if (tipo == 2)
            {
                dados[0] = "\nEN: Which Music category do you want to list? | PT: Qual a categoria de Músicas que pretende listar?\n";
                dados[1] = "Música";
                dados[2] = "\nEN: There isn't a category with that name | PT: Não existe nenhuma categoria com esse nome.\n";
                dados[3] = "\nA categoria existe!";

            }
            else if (tipo == 3)
            {
                dados[0] = "\nEN: Which Picture category do you want to list? | PT: Qual a categoria of pictures que pretende listar?\n";
                dados[1] = "Fotografia";
                dados[2] = "\nEN: There isn't a category with that name | PT: Não existe nenhuma categoria com esse nome.\n";
                dados[3] = "\n A categoria foi encontrada. \n";
            }

            categoria_temp = converter_arraylist_elementos(listadecategorias);
            contador999 = 0;
            contador888 = 0;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(dados[0]);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nATTENTION: Search is case sensitive!\n");
            Console.ResetColor();
            escolha_listagem = Console.ReadLine();
            foreach (string value in listadecategorias)
            {
                contador999 = contador999 + 1;
                if ((value) == escolha_listagem)
                {
                    contador888 = contador888 + 1;
                }
            }
            if (contador888 == 0)
            {
                Console.WriteLine(dados[2]);
            }
            else
            {
                Console.WriteLine(dados[3]);
                elemento_temp = converter_arraylist_elementos(listadeelementos);
                contador888 = 0;
                contador999 = 0;
                foreach (string value in listadeelementos)
                {
                    contador999 = contador999 + 1;
                    if ((value) == escolha_listagem)
                    {
                        if (elemento_temp[contador999 - 2] == dados[1])
                        {
                            contador888 = contador888 + 1;
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("\nQuantity of records found: {0}\n\n", contador888);
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine("ID: {0} \n Nome do elemento \"{5}\": {1} \n Categoria: {2} \n Localização: {3} \n Data: {4} \n", elemento_temp[contador999 - 4], elemento_temp[contador999 - 3], elemento_temp[contador999 - 1], elemento_temp[contador999], elemento_temp[contador999 + 1], dados[1]);
                            Console.ResetColor();
                        }
                    }
                }
                if (contador888 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\nHowever there aren't {0}s in that category\n", dados[1]);
                    Console.ResetColor();
                }
            }
        }

        /// <summary>
        /// Method that lists all elements for a certain element type (Filme-Movie, Música-Music, Fotografrias-Pictures).
        /// </summary>
        /// <param name="listadeelementos"></param>
        /// <param name="dados">Type of data to show the elements. If this param value is equal to 4 it shows all elements of all types instead</param>
        static void lista_elementos_pedidos(ArrayList listadeelementos, string dados)
        {
            int contador999, contador888 = 0;    //counter varibles to support this method
            string[] elemento_temp;             //temporary arrays used in this method

            if (dados == "Elemento")
            {
                lista_elementos_pedidos(listadeelementos, "Filme");
                lista_elementos_pedidos(listadeelementos, "Música");
                lista_elementos_pedidos(listadeelementos, "Fotografia");
                return;
            }

            elemento_temp = converter_arraylist_elementos(listadeelementos);
            contador999 = 0;
            contador888 = 0;

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\nListagem de {0}(s): \n\n", dados);
            Console.ResetColor();
            foreach (string value in listadeelementos)
            {
                contador999 = contador999 + 1;
                if ((value) == dados)
                {
                    contador888 = contador888 + 1;
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(" ID of elment: \t{0} \n Name of(a) {5}: \t{1} \n Category: \t\t{2} \n Location/Path: \t\t{3} \n Date: \t\t\t{4} \n\n-------------------------------------------------------------\n", elemento_temp[contador999 - 3], elemento_temp[contador999 - 2], elemento_temp[contador999], elemento_temp[contador999 + 1], elemento_temp[contador999 + 2], dados);
                    Console.ResetColor();
                }
            }
            if (contador888 == 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n***************************************************************\nElements of the type {0}s not found in your library\n***************************************************************\n", dados);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(" Found {0} {1}(s)... \n\n***************************************************************\n", contador888, dados);
                Console.ResetColor();
            }
        }

        /// <summary>
        /// EN: Method to save elements in the array to an ArrayList
        /// PT:Método para guardar os elementos do array numa ArrayList. Recebe como argumento o array com os dados dos elementos/categorias/empréstimos, e também recebe dois argumentos do tipo inteiro necessários para o bom funcionamento dos ciclos.
        /// </summary>
        /// <param name="array_para_transferir">Array variable with the data from elements/categories/rentals</param>
        /// <param name="numero_de_elementos">Number of elements</param>
        /// <param name="numero_de_campos">Number of fields for each element</param>
        /// <returns></returns>
        static ArrayList transfere_elementos_do_array_para_arraylist(string[,] array_para_transferir, int numero_de_elementos, int numero_de_campos)
        {
            ArrayList listadeelementos = new ArrayList();
            for (int i = 0; i < numero_de_elementos; i++)
            {
                for (int k = 0; k < numero_de_campos; k++)
                {
                    listadeelementos.Add(array_para_transferir[i, k]);
                }
            }
            return listadeelementos;
        }

        /// <summary>
        /// Method that validates if data inserted is an integer value
        /// </summary>
        /// <param name="dado_a_verificar"></param>
        /// <returns>Returns 1 if true, returns 2 if false</returns>
        static int veririfica_se_inteiro(string dado_a_verificar)
        {
            try
            {
                Int32.Parse(dado_a_verificar);
                return 1;
            }
            catch (FormatException)
            {
                return 2;
            }
        }

        /// <summary>
        /// PT: Método que verifica se o argumento do tipo string é igual a algum valor existente na ArrayList dada , pois quando se adiciona a informação que queremos adicionar um id correspondente a um elemento, é sempre bom verificar se esse id realmente existe. devolve 1 caso exista e devolve 0 caso contrário
        /// PT: IMPORTANTE!!! O nome do método ficou como "verifica_id_elementos" no entanto é usado para verificar qualquer tipo de elementos, e não só elementos de id como o nome sugere.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="array_list_para_verificar_existencia"></param>
        /// <returns></returns>
        static int verifica_id_elementos(string id, ArrayList array_list_para_verificar_existencia)
        {
            foreach (string value in array_list_para_verificar_existencia)
            {
                if (id == value)
                {
                    return 1;
                }
            }
            return 0;
        }


        static void Main()
        {
            //EN: read file index.txt to check for last session and create a new backup directory in case you may want to recover last session data
            //PT: iniciar a leitura do ficheiro index.txt para verificar a ultima sessao e criar novas directorias para o backup histórico
            string filepath_backup = "index.txt";
            int[] leitura_index = leituradefiles(filepath_backup);
            int numero_de_usos = leitura_index[0];

            //EN: path where the files will be created and save all data
            //PT: definir o local dos ficheiros que guardam os dados da aplicação
            string filepath = "backup_" + Convert.ToString(numero_de_usos) + "\\elements.txt";
            string filepath_emprestimos = "backup_" + Convert.ToString(numero_de_usos) + "\\emprestimos.txt";
            string filepath_categorias = "backup_" + Convert.ToString(numero_de_usos) + "\\categorias.txt";

            //EN: read file and check how many elements and id quantity exist
            //PT: iniciar a leitura do ficheiro de texto para verificar quantos elementos e quantidade de ids adicionados contém.
            int[] leitura_elementos = leituradefiles(filepath);             //PT: criou-se um método para fazer a leitura. Este método foi criado apenas numa fase final do trabalho
            int elementosnr = leitura_elementos[0];                         //PT: passam-se os valores do array para as variáveis
            int id_quantidade = leitura_elementos[1];                       //PT: passam-se os valores do array para as variáveis
            string[,] elementos = lerelementos(elementosnr, filepath, 6);   //PT: cria-se um array bi dimensional com o nome elementos que é preenchido através do método de ler os elementos. Este array é preenchido através de um método criado para o fazer.

            //EN: read file "emprestimos.txt"
            //PT: iniciar a leitura do ficheiro de texto "emprestimos.txt" para fazer a mesma vericação anterior mas agora para os empréstimos
            int[] leitura_emprestimos = leituradefiles(filepath_emprestimos);
            int emprestimosnr = leitura_emprestimos[0];
            int id_quantidade_emprestimos = leitura_emprestimos[1];
            string[,] emprestimos = lerelementos(emprestimosnr, filepath_emprestimos, 5);

            //EN: read file "categorias.txt"
            //PT: iniciar a leitura do ficheiro de texto "categorias.txt"
            int[] leitura_categorias = leituradefiles(filepath_categorias);
            int categoriasnr = leitura_categorias[0];
            int id_quantidade_categorias = leitura_categorias[1];
            string[,] categorias = lerelementos(categoriasnr, filepath_categorias, 2);

            //EN: array containing the data that will be saved the elements to the file
            //PT: declaração de arrays que vão ser necessários para guardar os dados no final do programa para voltar a gravar nos ficheiros.
            string[] arrayfinal_convertido;                     //EN: array for elements | PT: para os elementos multimédia
            string[] arrayfinal_convertido_emprestimos;         //EN: array for rentals | PT: para os empréstimos
            string[] arrayfinal_convertido_categorias;          //EN: array for categories | PT: para as categorias

            //EN: Same as previous array variables but Mutable ArrayLists this time
            //PT: declaração das ArrayList's necessárias para a manipulação de dados durante a execução da aplicação, o numero de valor inteiro no argumento dos métodos serve para identificar o número de campos
            ArrayList listadeelementos = transfere_elementos_do_array_para_arraylist(elementos, elementosnr, 6);           //EN: array for elements | PT: ArrayList para todos os elementos de multimédia
            ArrayList listadeemprestimos = transfere_elementos_do_array_para_arraylist(emprestimos, emprestimosnr, 5);     //EN: array for rentals | PT: ArrayList para os empréstimos
            ArrayList listadecategorias = transfere_elementos_do_array_para_arraylist(categorias, categoriasnr, 2);        //EN: array for categories | PT: ArrayList para as categorias

            //EN: global variables for general purposes in this application
            //PT: declaração de variáveis globais e arrays necessários ao longo do programa
            string[] novoelemento = new string[6];               //PT: array que vai guardar os dados que vão ser adicionados pelo utilizador ao longo da execução da aplicação. este array será utilizado várias vezes à medida que o utilizador adiciona dados através de um método. Este array pode guardar no máximo 6 elementos.
            int estado, save;                                    //PT: variável necessária para a navegação entre menus
            int verificador, check_id_exists, check_id_exists2;  //PT: variáveis para algumas verificações de dados (protecções), tipo de verificação: Existência de dados repetidos
            string nome_updated;                                 //PT: variáveis para algumas verificações de dados (protecções), tipo de verificação: Existência de dados repetidos
            string verificarid;                                  //PT: variavel responsavel pela acção de remover o elemento da arraylist
            int counter, counter2;                               //PT: variavel contador necessário para o uso dentro do foreach da arraylist
            string update_element;                               //PT: variavel necessária para o update de elementos da arraylis
            int contador999, contador888 = 0;                    //PT: contadores necessários para verificar se encontra os elementos pedidos nas opções de listagens
            string[] elemento_temp, emprestimos_temp;            //PT: arrays temporáriros que são usados nas consultas de elementos mais detalhados
            string save_state;                                   //PT: string necessária para saber se o utilizador quer guardar os dados

            estado = menu();    //PT: Iniciar a navegação do menu chamando o método que apresenta o menu

            do
            {
                //EN: Selected option: Add new element
                //PT: Opção escolhida: Adicionar Elementos de multimédia
                if (estado == 1)
                {

                    elementosnr = elementosnr + 1;                                                          //PT: incrementa-se um valor à variàvel "elementosnr" para sabermos quantas vezes adicionámos elementos no final do programa.
                    id_quantidade = id_quantidade + 1;                                                      //PT: incrementa-se um valor também ao id_quantidade para usarmos como parametro, para a funcionalidade de fazer auto_increment a adicionar id's nos dados que vao ser inseridos ao longo da existência da base de dados contida nos ficheiros
                    novoelemento = adicelemento(id_quantidade, 1, 6, listadeelementos, listadecategorias, listadeemprestimos, elementosnr - 1);  //PT: o array "novoelemento" é preenchido através do método criado para adicionar elementos // o ultimo argumento so é relevante para adicionar novos empréstimos

                    //PT: Este ciclo vai adicionar estes novos dados à ArrayList criada para os elementos de multimédia
                    for (int i = 0; i < 6; i++)
                    {
                        listadeelementos.Add(novoelemento[i]);
                    }

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\n Adicionou um elemento com sucesso!\n\n");
                    Console.ResetColor();
                    estado = menu();
                    Console.WriteLine("");
                }
                //EN: Selected option: Remove an element
                //PT: Opção escolhida: Remover Elementos de Multimédia
                else if (estado == 2)
                {
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\n Insert the correspondig ID to the element you wish to remove:\n");
                        Console.ResetColor();
                        verificarid = Console.ReadLine();

                        //EN: check if the element exists
                        //PT: verificar se existe o elemento de multimédia com o id inserido
                        check_id_exists = verifica_id_elementos(verificarid, listadeelementos);
                        verificador = veririfica_se_inteiro(verificarid);                           //PT: novo método que foi criado para verificar se o valor inserido é do tipo inteiro ou não
                        if (check_id_exists == 0 && verificador == 1)                               //PT: se o tipo de dados estiver bem inserido mas o id não existir, então mostra uma mensagem a avisar que não existe nenhum elemento multimédia com o id pedido, caso os dados estejam errados, apenas volta a repetir a pergunta sem o aviso que só faz sentido mostrar depois do tipo de dados no id estiver correctamente inserido
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n The specified element id doesn't exist");
                            Console.ResetColor();
                        }
                    } while (verificador == 2 || check_id_exists == 0);
                    elementosnr = elementosnr - 1;                                                          //PT: Da mesma forma que se incrementa um valor quando adicionamos um elemento, o mesmo temos que fazer ao remover um elemento, subtraindo um valor no contador
                    counter = 0;                                                                            //PT: É necessário colocar o contador a 0 cada vez que o utilizador pede para remover um elemento para o funcionamento do Remove  ser correcto

                    //EN: This cycle will read all elements from the object in ArrayList "listadeelements" one by one.
                    //PT: Este ciclo vai ler todos os elementos da ArrayList "listadeelementos" 1 a 1
                    foreach (string value in listadeelementos)
                    {
                        if (verificarid == (value))                                                         //PT: condição onde verifica se o id é igual ao elemento actual da arraylist
                        {
                            //PT: Ciclo que remove os campos do id pedido
                            for (int i = 0; i < 6; i++)
                            {
                                listadeelementos.RemoveAt(counter);
                            }
                            break;                                                                          //PT: O break é necessário, pois se não o colocarmos, o ciclo continua e vai dar erro
                        }
                        counter = counter + 1;
                    }

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Element removed successfuly!\n\n");
                    Console.ResetColor();
                    estado = menu();
                    Console.WriteLine("");
                }
                //EN: Selected option: Edit an element
                //PT: Opção escolhida: Alterar dados dos elementos Multimédia
                else if (estado == 3)
                {
                    //EN: some insert data protection validation
                    //PT: proteção para o utilizador do software durante o processo de inserir dados
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\n->Insert the ID of the element you want to edit");
                        Console.ResetColor();
                        verificarid = Console.ReadLine();
                        check_id_exists = verifica_id_elementos(verificarid, listadeelementos);
                        verificador = veririfica_se_inteiro(verificarid);
                        if (check_id_exists == 0 && verificador == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n The specified element id doesn't exist!");
                            Console.ResetColor();
                        }
                    } while (verificador == 2 || check_id_exists == 0);

                    counter = 0;

                    //EN: cycle used to change the element in the ArrayList object "listadeelementos"
                    //PT: Ciclo que faz a alteração dos campos da ArrayList "listadeelementos"
                    foreach (string value in listadeelementos)
                    {
                        if (verificarid == (value))     //PT: Condição que verifica se o id é igual ao elemento actual da arraylist. A comparação é feita em string.
                        {
                            do
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine("\n->New name for the element with ID \"{0}\".", (value));
                                Console.ResetColor();
                                update_element = Console.ReadLine();

                                //PT: nesta particular verificação, é necessário verificar se existe este campo inserido tanto nos elementos de multimédia como nas categorias, a aplicação está feita de modo a que não possam existir nomes repetidos, nem nomes iguais aos nomes das categorias e vice-versa
                                check_id_exists = verifica_id_elementos(update_element, listadeelementos);      //PT: dá-se como argumento a arraylist de elementos de multimédia
                                check_id_exists2 = verifica_id_elementos(update_element, listadecategorias);    //PT: dá-se como argumento a arraylist das categorias

                                verificador = veririfica_se_inteiro(update_element);

                                if ((check_id_exists == 1 && verificador == 2) || (check_id_exists2 == 1 && verificador == 2)) //PT: é necessário fazer a verificação para ambas variáveis. inicialmente estava criado com 2 ciclos if indepentes, mas após uma pesquisa, descobri que se podia meter este tipo de condição
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n This is already a record with the name-value you are trying to choose. Please choose another name for the element");
                                    Console.ResetColor();
                                    check_id_exists = 1;    //PT: o valor muda consoante a necessidade para a verificação do ciclo while
                                }
                                else
                                {
                                    check_id_exists = 0;    //PT: o valor muda consoante a necessidade para a verificação do ciclo while
                                }

                            } while (verificador == 1 || check_id_exists == 1 || update_element == "" || update_element == "Filme" || update_element == "filme" || update_element == "Música" || update_element == "música" || update_element == "musica" || update_element == "Musica" || update_element == "Fotografia" || update_element == "fotografia");

                            listadeelementos.Insert(counter + 1, update_element);
                            nome_updated = update_element;                          //PT: necessária para a protecção na nova localização, é necessário verificar se a localização que vamos introduzir é igual ao valor temporário que inserimos no nome

                            do
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine("\n->Choose the new type for the element of ID \"{0}\" (1-Filmes(Movie) 2-Música(Music) 3-Fotografia(Picture)).", (value));
                                Console.ResetColor();
                                update_element = Console.ReadLine();
                                if (update_element == "1")
                                {
                                    update_element = "Filme";
                                }
                                else if (update_element == "2")
                                {
                                    update_element = "Música";
                                }
                                else if (update_element == "3")
                                {
                                    update_element = "Fotografia";
                                }
                            } while (update_element != "Filme" && update_element != "Música" && update_element != "Fotografia");

                            listadeelementos.Insert(counter + 2, update_element);

                            do
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine("\n->Name of category for element update with ID \"{0}\".", (value));
                                Console.ResetColor();
                                update_element = Console.ReadLine();

                                check_id_exists = verifica_id_elementos(update_element, listadecategorias);
                                verificador = veririfica_se_inteiro(update_element);
                                if (check_id_exists == 0 && verificador == 2)
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\nWARNING: The selected category doesn't exist, please select an existing category\n");
                                    Console.ResetColor();
                                }


                            } while (verificador == 1 || check_id_exists == 0 || update_element == "" || update_element == "Filme" || update_element == "filme" || update_element == "Música" || update_element == "música" || update_element == "musica" || update_element == "Musica" || update_element == "Fotografia" || update_element == "fotografia");
                            listadeelementos.Insert(counter + 3, update_element);

                            do
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.WriteLine("\n->Insert the location or path for the element with ID \"{0}\".\n\n");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("ATTENTION: The location format should be something similiar to: C:\\users\\documents\\filmes\\\n", (value));
                                Console.ResetColor();
                                update_element = Console.ReadLine();

                                verificador = veririfica_se_inteiro(update_element);

                            } while (verificador == 1 || update_element == "");

                            update_element = update_element + nome_updated;                 //PT: código para adicionar o nome do ficheiro ou elemento à directoria
                            listadeelementos.Insert(counter + 4, update_element);

                            //PT: Depois de inserir os campos na ArrayList, falta ainda remover os campos antigos, o ciclo que se segue faz isso
                            for (int i = 0; i < 4; i++)
                            {
                                listadeelementos.RemoveAt(counter + 5);     //PT: Adiciona-se remove-se na posição counter+5 4 vezes, porque foram inseridos 4 campos novos e pela maneira como funciona o insert em ArrayLists, que insere no indice que indicamos, fazendo os restantes campos subirem os seus respectivos indices
                            }
                            break;
                        }
                        counter = counter + 1;
                    }

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\nElement Updated Sucessfully!\n\n");
                    Console.ResetColor();
                    estado = menu();
                    Console.WriteLine("");
                }
                //EN: Selected option: Create a rental
                //PT: Opção escolhida: Adicionar Empréstimos
                else if (estado == 4)
                {
                    id_quantidade_emprestimos = id_quantidade_emprestimos + 1;
                    novoelemento = adicelemento(id_quantidade_emprestimos, 2, 5, listadeelementos, listadecategorias, listadeemprestimos, emprestimosnr);
                    emprestimosnr = emprestimosnr + 1;

                    for (int i = 0; i < 5; i++)
                    {
                        listadeemprestimos.Add(novoelemento[i]);
                    }

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\nRental created with success\n\n");
                    Console.ResetColor();
                    estado = menu();
                    Console.WriteLine("");
                }
                //EN: Selected option: Update rental
                //PT: Opção escolhida: Actualizar Empréstimos
                else if (estado == 5)
                {
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.WriteLine("\n->Insert element's ID to change the rental status:");
                        Console.ResetColor();
                        verificarid = Console.ReadLine();
                        check_id_exists = verifica_id_elementos(verificarid, listadeemprestimos);
                        verificador = veririfica_se_inteiro(verificarid);
                        if (check_id_exists == 0 && verificador == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n There isn't rentals with the element ID selected");
                            Console.ResetColor();
                        }
                    } while (verificador == 2 || check_id_exists == 0);
                    counter = 0; counter2 = 0;
                    emprestimos_temp = converter_arraylist_elementos(listadeemprestimos); //PT: converter a ArrayList para usar os dados dos empréstimos para actualizar o valor do id do filme emprestado para o estado entregue
                    foreach (string value in listadeemprestimos)
                    {
                        counter2 = counter2 + 1;
                        if (verificarid == (value))
                        {
                            //PT: Actualizar Campo "Por Entregar" para "Entregue em $data_de_entrega"
                            DateTime data_de_entrega = DateTime.Now;
                            update_element = "Returned on: " + Convert.ToString(data_de_entrega);
                            listadeemprestimos.RemoveAt(counter + 3);
                            listadeemprestimos.Insert(counter + 3, update_element);

                            //PT: actualizar o valor do id do filme emprestado para um id com o formato entregue
                            listadeemprestimos.RemoveAt(counter + 4);
                            listadeemprestimos.Insert(counter + 4, emprestimos_temp[counter2 + 3] + "-e");
                            break;
                        }
                        counter = counter + 1;
                    }
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\nRental status updated successfully\n\n");
                    Console.ResetColor();
                    estado = menu();
                    Console.WriteLine("");
                }
                //EN: Selected option: Add category
                //PT: Opção escolhida: Adicionar Categorias
                else if (estado == 7)
                {
                    categoriasnr = categoriasnr + 1;
                    id_quantidade_categorias = id_quantidade_categorias + 1;
                    novoelemento = adicelemento(id_quantidade_categorias, 3, 2, listadeelementos, listadecategorias, listadeemprestimos, categoriasnr - 1);

                    for (int i = 0; i < 2; i++)
                    {
                        listadecategorias.Add(novoelemento[i]);
                    }

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\nCategory added successfully\n\n");
                    Console.ResetColor();
                    estado = menu();
                    Console.WriteLine("");
                }
                //EN: Selected option: List all elements from the library/database
                //PT: Opção escolhida: Listar todos os elementos de Multimédia
                else if (estado == 11)
                {
                    Console.Clear();
                    lista_elementos_pedidos(listadeelementos, "Elemento");
                    Console.WriteLine("");
                    estado = menu();
                    Console.WriteLine("");
                }
                //EN: Selected option: List all categories
                //PT: Opção escolhida: Listar todas as categorias
                else if (estado == 12)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\nCategories list:\n");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    foreach (string value in listadecategorias)
                    {
                        Console.WriteLine(value);
                    }
                    Console.ResetColor();
                    Console.WriteLine("");
                    estado = menu();
                    Console.WriteLine("");
                }
                //EN: Selected option: List all rentals
                //PT: Opção escolhida: Listar todos dos empréstimos
                else if (estado == 13)
                {

                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\nRentals list:\n");
                    Console.ResetColor();
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    foreach (string value in listadeemprestimos)
                    {

                        Console.WriteLine(value);
                    }
                    Console.ResetColor();
                    Console.WriteLine("");
                    estado = menu();
                    Console.WriteLine("");
                }
                //EN: Selected option: List movies
                //PT: Opção escolhida: Listar apenas os filmes
                else if (estado == 14)
                {
                    lista_elementos_pedidos(listadeelementos, "Filme");
                    Console.WriteLine("");
                    estado = menu();
                    Console.WriteLine("");
                }
                //EN: Selected option: List music
                //PT: Opção escolhida: Listar apenas as Músicas
                else if (estado == 15)
                {
                    lista_elementos_pedidos(listadeelementos, "Música");
                    Console.WriteLine("");
                    estado = menu();
                    Console.WriteLine("");
                }
                //EN: Selected option: List pictures
                //PT: Opção escolhida: Listar apenas as Fotografias
                else if (estado == 16)
                {
                    lista_elementos_pedidos(listadeelementos, "Fotografia");
                    Console.WriteLine("");
                    estado = menu();
                    Console.WriteLine("");
                }
                //EN: Selected option: list rentals
                //PT: Opção escolhida: Listar todos os empréstimos por entregar
                else if (estado == 8)
                {
                    elemento_temp = converter_arraylist_elementos(listadeemprestimos);
                    contador999 = 0;
                    contador888 = 0;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\nRentals with active status:\n\n***************************************************************\n");
                    Console.ResetColor();
                    foreach (string value in listadeemprestimos)
                    {
                        contador999 = contador999 + 1;
                        if ((value) == "Por Entregar")
                        {
                            contador888 = contador888 + 1;
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.WriteLine("\n Rental ID: \t\t\t{0} \n Nome/Contacto da pessoa empréstimo: \t{1} \n Data do empréstimo: \t\t\t{2} \n ID do elemento emprestado: \t\t{3} \n\n-------------------------------------------------------------\n", elemento_temp[contador999 - 4], elemento_temp[contador999 - 3], elemento_temp[contador999 - 2], elemento_temp[contador999]);
                            Console.ResetColor();
                        }
                    }
                    if (contador888 == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\nActive rentals not found in the database");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\n {0} active rentals found... \n", contador888);
                        Console.ResetColor();
                    }
                    Console.WriteLine("");
                    estado = menu();
                    Console.WriteLine("");
                }
                //EN: Selected option: List movies by category
                //PT: Opção escolhida: Listar Filmes por categoria
                else if (estado == 17)
                {
                    verifica_elementos_na_categoria(listadeelementos, listadecategorias, 1);
                    Console.WriteLine("");
                    estado = menu();
                    Console.WriteLine("");
                }
                //EN: Selected option: List music by category
                //PT: Opção escolhida: Listar Música por categoria
                else if (estado == 18)
                {
                    verifica_elementos_na_categoria(listadeelementos, listadecategorias, 2);
                    Console.WriteLine("");
                    estado = menu();
                    Console.WriteLine("");
                }
                //EN: Selected option: List pictures by category
                //PT: Opção escolhida: Listar Fotografias por categoria
                else if (estado == 19)
                {
                    verifica_elementos_na_categoria(listadeelementos, listadecategorias, 3);
                    Console.WriteLine("");
                    estado = menu();
                    Console.WriteLine("");
                }
                else if (estado == 9)
                {
                    Console.Clear();
                    do
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\n\n\n  *******************************************************************");
                        Console.WriteLine("  *******************************************************************");
                        Console.WriteLine("  ***                                                             ***");
                        Console.WriteLine("  ***   Are you sure you want to save the data?                   ***");
                        Console.WriteLine("  ***                                                             ***");
                        Console.WriteLine("  ***                                                             ***");
                        Console.WriteLine("  ***                                             1-YES   2-No    ***");
                        Console.WriteLine("  ***                                                             ***");
                        Console.WriteLine("  *******************************************************************");
                        Console.WriteLine("  *******************************************************************");
                        Console.ResetColor();
                        save_state = Console.ReadLine();
                    } while (save_state != "1" && save_state != "2");
                    save = Convert.ToUInt16(save_state);
                    if (save == 1)
                    {
                        numero_de_usos = numero_de_usos + 1;
                    }
                    //EN: Convert data in ArrayList object to array and save it.
                    //PT: Guardar os dados das ArrayLists para arrays
                    arrayfinal_convertido = converter_arraylist_elementos(listadeelementos);
                    arrayfinal_convertido_emprestimos = converter_arraylist_elementos(listadeemprestimos);
                    arrayfinal_convertido_categorias = converter_arraylist_elementos(listadecategorias);

                    //EN: save all application data to the files
                    //PT: Executar a operação final de guardar os dados nos ficheiros
                    closeapplication(save, elementosnr, filepath, arrayfinal_convertido, emprestimosnr, filepath_emprestimos, arrayfinal_convertido_emprestimos, id_quantidade, id_quantidade_emprestimos, id_quantidade_categorias, categoriasnr, filepath_categorias, arrayfinal_convertido_categorias, filepath_backup, numero_de_usos);

                    Console.Clear();
                    Console.WriteLine("");
                    estado = menu();
                    Console.WriteLine("");
                }
                else if (estado == 10)
                {
                    Console.Clear();
                    Console.WriteLine("");
                    estado = menu();
                    Console.WriteLine("");
                }
            } while (estado != 666);

        }
    }
}