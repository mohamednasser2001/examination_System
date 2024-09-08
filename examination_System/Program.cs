namespace examination_System
{
    class question
    {
        public string qtext { get; set; }
        public int marks { get; set; }
    }
    class tfquestion : question
    {
        public bool ansewr { set; get; }
    }
    class multiplequestion : question
    {
        public List<string> Choose { get; set; }
        public string answer { get; set; }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            Console.Title = "examination System";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.WriteLine("======== Welcom To Exam System ======");

            List<question> questions = new List<question>();
            int count = 0;

            while (true)
            {
                try
                {
                    Console.Write("enter the number of question: ");
                    count = int.Parse(Console.ReadLine());

                    if (count <= 0)
                    {

                        Console.WriteLine("Enter a valid value");
                        Console.Write("enter the number of question: ");
                        count = int.Parse(Console.ReadLine());


                    }
                    else
                    {
                        break;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }

            }

            for (int i = 0; i < count; i++)
            {
                int type = 0;
                while (true)
                {
                    try
                    {
                        Console.WriteLine($"enter details{i + 1} : ");
                        Console.WriteLine("[1]-choose   [2]-true (or) false");
                        type = int.Parse(Console.ReadLine());
                        if (type != 1 && type != 2)
                        {
                            Console.Write("Invalid type!!!!!! [1]-choose   [2]-true (or) false ");

                        }
                        else
                        {
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Invalid input! Please enter a valid integer (1 or 2).");
                    }
                }

                if (type == 1)
                {
                    var mcq = new multiplequestion();
                    Console.Write("Enter the question text: ");
                    mcq.qtext = Console.ReadLine();
                    int countchoose = 0;
                    while (true)
                    {
                        try
                        {
                            Console.Write("Enter the nmber choose :");
                            countchoose = int.Parse(Console.ReadLine());
                            if (countchoose <= 0)
                            {
                                Console.WriteLine("Enter an integer number greater than zero");
                            }
                            else
                            {
                                break;
                            }

                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please enter a valid integer.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }

                    mcq.Choose = new List<string>();
                    for (int j = 0; j < countchoose; j++)
                    {
                        Console.WriteLine($"Enter Choose{j + 1} ");
                        mcq.Choose.Add(Console.ReadLine());

                    }
                    Console.Write("enter the text of the correct choice :");
                    mcq.answer = Console.ReadLine();

                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Enter the marks:");
                            mcq.marks = int.Parse(Console.ReadLine());
                            if (mcq.marks <= 0)
                            {
                                Console.WriteLine("mark is not correct ");

                            }
                            else
                            {
                                break;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please enter a valid integer");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                    }
                    questions.Add(mcq);
                }
                else if (type == 2)
                {
                    var tfq = new tfquestion();
                    Console.Write("enter the question : ");
                    tfq.qtext = Console.ReadLine();


                    while (true)
                    {
                        try
                        {

                            Console.Write("Enter the correct answer (true/false): ");
                            tfq.ansewr = bool.Parse(Console.ReadLine());
                            break;

                        }
                        catch (FormatException)
                        {
                            Console.Write("Enter the correct answer (true/false): ");
                        }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }

                    }


                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Enter the marks:");
                            tfq.marks = int.Parse(Console.ReadLine());
                            if (tfq.marks <= 0)
                            {
                                Console.WriteLine("mark is not correct ");

                            }
                            else
                            {
                                break;
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please enter a valid integer");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                    }
                    questions.Add(tfq);
                }

            }
            int examtime = 0;
            while (true)
            {
                Console.Write("Enter the test time in seconds: ");
                examtime = int.Parse(Console.ReadLine());
                try
                {
                    if (examtime <= 0)
                    {
                        Console.WriteLine("Error Enter the test time in seconds: ");


                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error Enter the test time in seconds: ");

                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }

            //=====================================
            // start the exam   ===================
            //=====================================
            Console.Clear();
            Console.WriteLine("The exam is starting now!");
            Console.WriteLine("Enter Name");
            string Name = Console.ReadLine();


            int marks = 0;
            int degree = 0;
            int time = examtime;

            Timer timer = new Timer((o) =>
            {
                time--;
                if (time <= 0)
                {
                    Console.WriteLine("time is end:");
                    ShowResult(marks, degree, Name);
                    Environment.Exit(0);
                }
            }, null, 0, 1000);


            foreach (var question in questions)
            {
                Console.Clear();
                Console.WriteLine(question);
                Console.WriteLine($"Time Left {time} seconds");

                if (question is multiplequestion mcq)
                {
                    for (int i = 0; i < mcq.Choose.Count; i++)
                    {
                        //Console.WriteLine($"{i + 1}. {mcq.Choose[i]}");
                    }
                    Console.Write("enter the choice number: ");
                    string answer = Console.ReadLine();
                    if (mcq.Choose[int.Parse(answer) - 1] == mcq.answer)
                    {
                        marks += mcq.marks;
                    }
                    degree += mcq.marks;
                }
                else if (question is tfquestion tfq)
                {
                    Console.WriteLine("1. true");
                    Console.WriteLine("2. false");
                    Console.Write("Your answer (enter 1 or 2): ");
                    string answer = Console.ReadLine();

                    bool userAnswer = answer == "1";

                    if (userAnswer == tfq.ansewr)
                    {
                        degree += tfq.marks;
                    }
                    marks += tfq.marks;

                }


            }

            ShowResult(degree, marks, Name);
        }


        static void ShowResult(object degree, object marks, string Name)
        {
            Console.Clear();
            Console.WriteLine("====== Exam Results ======");
            Console.WriteLine($"Hello {Name}");
            Console.WriteLine($"Total Marks: {marks}");
            Console.WriteLine($"Obtained Marks: {degree}");

        }

    }




}
            

        
    
         
