namespace Project_Week1_Bank_DW_Management
{
    class Customer
    {
        public int number;  // [고객 번호]
        public string name; // [고객 이름]
        public int age;     // [고객 나이]

        public Customer()
        {
            // 기본 생성자
        }

        public Customer(int number, string name, int age)
        {
            this.number = number;
            this.name = name;
            this.age = age;

        }

        ////////////////////////////////////////////////
        // [get] 접근자 : 필드 값 반환
        // [set] 접근자 : 필드 값 대입
        public int GetNumber()
        {
            return number;

        }


        public void SetNumber(int number)
        {
            this.number = number;

        }


        public string GetName()
        {
            return name;

        }


        public void SetName(string name)
        {
            this.name = name;

        }


        public int GetAge()
        {
            return age;

        }


        public void SetAge(int age)
        {
            this.age = age;

        }


    }


}