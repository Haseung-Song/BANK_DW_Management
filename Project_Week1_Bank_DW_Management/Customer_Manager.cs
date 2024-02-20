using System;
using System.Collections.Generic;
using System.IO;

namespace Project_Week1_Bank_DW_Management
{
    class Customer_Manager
    {
        public List<Customer> Customer_List; // [List] 함수 이용하여 [Customer_List] 구현

        public Customer_Manager()
        {
            Customer_List = new List<Customer>(); // [List] 함수 선언 및 객체 생성


        }


        // 1. [고객 정보] 등록
        public void EnrollCustomers(int number, string name, int age)
        {
            // [customer] 객체(번호, 이름, 나이) 생성 및 초기화
            Customer customer = new Customer(number, name, age);

            Customer_List.Add(customer); // [Customer_List]에 [고객 정보] 등록

            return; // 반환

        }


        // 2. [고객 정보] 삭제
        public void RemoveCustomers(int number) // [고객 번호]를 이용하여 [고객 정보] 삭제
        {
            for (int i = 0; i < Customer_List.Count; i++) // [customer_List] 원소 개수만큼 반복하여
            {
                if (Customer_List[i].GetNumber().Equals(number)) // (i번째) 반환 값이 [고객 번호]와 같으면
                {
                    // 1. RemoveAt(i) 메소드 활용
                    Customer_List.RemoveAt(i); // 그 (i번째) 고객을 삭제

                    return; // 반환

                    // 2. Clear() 메소드 활용
                    // Customer_List.Clear();

                    //return; // 반환

                }

            }

        }


        // 3. [고객 정보] 저장
        public void SaveCustomers()
        {
            // # [customer.dat] 파일 생성
            // # 파일 경로는 지정해주는 편이 좋음. 디폴트 경로는 bin 폴더에 [.dat] 생성!
            FileStream fs = new FileStream(@"C:\Harry_SONG\Pre_CodingTest\Pre_VS\Project_Week1_Bank_DW_Management
\Project_Week1_Bank_DW_Management\bin\Debug\customer.dat", FileMode.Create, FileAccess.Write);

            StreamWriter sw = new StreamWriter(fs); // [customer.dat] 파일 쓰기

            // 1) 첫 번째 방법 : [for]문 사용하기!!!
            for (int i = 0; i < Customer_List.Count; i++) // [Customer_List] 원소 개수만큼 반복하여
            {
                Customer customer = Customer_List[i]; // [Customer_List] (i번째) 원소 [customer]에 저장!

                sw.WriteLine(customer.GetNumber()); // [customer.dat] 파일에 [고객 번호] 순서대로 저장!!
                sw.WriteLine(customer.GetName());   // [customer.dat] 파일에 [고객 이름] 순서대로 저장!!
                sw.WriteLine(customer.GetAge());    // [customer.dat] 파일에 [고객 나이] 순서대로 저장!!

            }

            // 2) 두 번째 방법 : [foreach]문 사용하기!!!
            //foreach (Customer customer in Customer_List)
            //{
            //   sw.WriteLine(customer.GetNumber()); // [customer.dat] 파일에 [고객 번호] 순서대로 저장!!
            //   sw.WriteLine(customer.GetName());   // [customer.dat] 파일에 [고객 이름] 순서대로 저장!!
            //   sw.WriteLine(customer.GetAge());    // [customer.dat] 파일에 [고객 나이] 순서대로 저장!!

            //}

            sw.Close(); // 스트림 닫기

            return; // 반환

        }


        // 4. [고객 정보] 로딩
        public void LoadCustomers()
        {
            int number;  // [고객 번호]
            string name; // [고객 이름]
            int age;     // [고객 나이]

            // [customer.dat] 파일 오픈
            FileStream fs = new FileStream("customer.dat", FileMode.OpenOrCreate, FileAccess.Read);

            StreamReader sw = new StreamReader(fs); // [customer.dat] 파일 읽기

            while (!sw.EndOfStream) // [customer.dat] 파일 끝에 도달할 때까지 [while]문 수행
            {
                number = Int32.Parse(sw.ReadLine()); // [customer.dat] 파일에서 [고객 번호] 한 줄씩 읽기!!
                name = sw.ReadLine();                // [customer.dat] 파일에서 [고객 이름] 한 줄씩 읽기!!
                age = Int32.Parse(sw.ReadLine());    // [customer.dat] 파일에서 [고객 나이] 한 줄씩 읽기!!
                
                EnrollCustomers(number, name, age); // [고객 정보](번호, 나이, 이름) 등록

            }

            sw.Close(); // 스트림 닫기

            return; // 반환

        }


        // 5. [고객 정보] 출력하기
        public void PrintsCustomers()
        {
            // 1) 첫 번째 방법 : [for]문 사용하기!!!
            for (int i = 0; i < Customer_List.Count; i++) // [Customer_List] 원소 개수만큼 반복하여
            {
                Customer customer = Customer_List[i]; // [Customer_List] (i번째) 원소 [customer]에 저장

                Console.WriteLine("┏━━━━━━━━━━━━━━━━━┓");
                Console.WriteLine("고객 번호 : {0} ", customer.GetNumber()); // [고객 번호] 출력
                Console.WriteLine("┃                                  ┃");
                Console.WriteLine("고객 이름 : {0} ", customer.GetName());   // [고객 이름] 출력
                Console.WriteLine("┃                                  ┃");
                Console.WriteLine("고객 나이 : {0} ", customer.GetAge());    // [고객 나이] 출력
                Console.WriteLine("┗━━━━━━━━━━━━━━━━━┛");

            }

            // 2) 두 번째 방법 : [foreach]문 사용하기!!!
            //foreach(Customer customer in Customer_List)
            //{
            //    Console.WriteLine("┏━━━━━━━━━━━━━━━━━┓");
            //    Console.WriteLine("고객 번호 : {0} ", customer.GetNumber()); // [고객 번호] 출력
            //    Console.WriteLine("┃                                  ┃");
            //    Console.WriteLine("고객 이름 : {0} ", customer.GetName());   // [고객 이름] 출력
            //    Console.WriteLine("┃                                  ┃");
            //    Console.WriteLine("고객 나이 : {0} ", customer.GetAge());    // [고객 나이] 출력
            //    Console.WriteLine("┗━━━━━━━━━━━━━━━━━┛");

            //}

            return; // 반환


        }

    }

}