using System;

namespace Project_Week1_Bank_DW_Management
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;  // 입력받을 [고객 번호]
            string name; // 입력받을 [고객 이름]
            int age;     // 입력받을 [고객 나이]

            Customer_Manager cm = new Customer_Manager(); // [cm] 객체 생성 및 초기화

            cm.LoadCustomers(); // [고객 정보] 불러오기

            Boolean run = true; // Boolean=[true] 설정!

            int balance = 0; // [balance] 초기화

            while (run) // 무한 loop문 : [true]인 동안 계속 실행
            {
                Console.WriteLine("-----고객 입출금 관리 시스템-----"); // 고객 입출금 관리 시스템
                Console.WriteLine("---------------------------------");
                Console.WriteLine("1. 고객 등록");
                Console.WriteLine("2. 고객 리스트");
                Console.WriteLine("3. 고객 삭제");
                Console.WriteLine("4. 고객 예금액");
                Console.WriteLine("5. 고객 출금액");
                Console.WriteLine("6. 고객 잔고액");
                Console.WriteLine("7. 종료");
                Console.WriteLine("---------------------------------");
                Console.Write("메뉴 번호를 입력하세요 >>> "); // [메뉴 선택]

                string str = Console.ReadLine(); // [문자열] 입력받기!!!!

                int menuNum = Int32.Parse(str); // [정수 -> 문자열] 변환!

                // switch문 실행, break문으로 인해 case문 실행마다 종료 후 while문 재실행!
                switch (menuNum)
                {
                    case 1: // 1번 선택
                        Console.Write("--당신의 번호를 입력하세요 >>> ");
                        number = Int32.Parse(Console.ReadLine()); // [고객 번호] 입력받기!

                        Console.Write("--당신의 이름을 입력하세요 >>> ");
                        name = Console.ReadLine();                // [고객 이름] 입력받기!

                        Console.Write("--당신의 나이를 입력하세요 >>> ");
                        age = Int32.Parse(Console.ReadLine());    // [고객 나이] 입력받기!

                        cm.EnrollCustomers(number, name, age);    // [고객 정보] 등록하기!
                        break;


                    case 2: // 2번 선택
                        Console.WriteLine("--고객 리스트를 출력합니다.--");

                        cm.PrintsCustomers();                      // [고객 정보] 출력하기!
                        break;


                    case 3: // 3번 선택
                        Console.WriteLine("--고객 리스트를 삭제합니다.--");
                        Console.Write("----삭제할 번호를 입력하세요 >>> ");
                        number = Int32.Parse(Console.ReadLine()); // [고객 번호] 입력받기!

                        cm.RemoveCustomers(number);               // [고객 정보] 삭제하기!
                        break;


                    case 4: // 4번 선택
                        Console.Write("----예금할 고객을 선택하세요 >>> ");
                        number = Int32.Parse(Console.ReadLine()); // [고객 번호] 입력받기!

                        for (int i = 0; i < cm.Customer_List.Count; i++) // [Customer_List] 원소 개수만큼 반복하여
                        {
                            if (cm.Customer_List[i].GetNumber().Equals(number)) // (i번째) 반환 값이 [고객 번호]와 같으면
                            {
                                Console.Write("예금액: ");
                                balance += Int32.Parse(Console.ReadLine()); // [예금액] 입력받기!!

                            }

                        }
                        break;


                    case 5: // 5번 선택
                        Console.Write("----출금할 고객을 선택하세요 >>> ");
                        number = Int32.Parse(Console.ReadLine()); // [고객 번호] 입력받기!

                        for (int i = 0; i < cm.Customer_List.Count; i++) // [Customer_List] 원소 개수만큼 반복하여
                        {
                            if (cm.Customer_List[i].GetNumber().Equals(number)) // (i번째) 반환 값이 [고객 번호]와 같으면
                            {
                                Console.Write("출금액: ");
                                balance -= Int32.Parse(Console.ReadLine()); // [출금액] 입력받기!!

                            }

                        }
                        break;


                    case 6: // 6번 선택
                        Console.Write("----확인할 고객을 선택하세요 >>> ");
                        number = Int32.Parse(Console.ReadLine()); // [고객 번호] 입력받기!

                        for (int i = 0; i < cm.Customer_List.Count; i++) // [Customer_List] 원소 개수만큼 반복하여
                        {
                            if (cm.Customer_List[i].GetNumber().Equals(number)) // (i번째) 반환 값이 [고객 번호]와 같으면
                            {
                                Console.Write("잔고액: " + balance); // balance [증감 차액] 출력!!!

                            }

                        }
                        break;


                    case 7: // 7번 선택
                        run = false;
                        break; // 반복문을 빠져나감!


                    default:
                        Console.WriteLine("번호를 잘못 입력하셨습니다.");
                        break;


                }
                Console.WriteLine();

            }
            Console.WriteLine("프로그램을 종료합니다.");

        }
    }
}