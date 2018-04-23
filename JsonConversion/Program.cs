using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.Data;
using System.Xml;
using System.Xml.Linq;

namespace JsonConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            //ListJsonConversion();

            //DataSetJsonConversion();

            //DataTableJsonConversion();

            XmlJsonConversion();

            Console.ReadLine();
        }

        /// <summary>
        /// XML Json Conversion
        /// </summary>
        private static void XmlJsonConversion()
        {
            string jsInput = "{\"Employee\": [{\"ID\":1,\"FName\":\"John\",\"LName\":\"Shields\",\"DOB\":\"12/11/1971\",\"Sex\":\"M\"},{\"ID\":2,\"FName\":\"Mary\",\"LName\":\"Jacobs\",\"DOB\":\"01/17/1961\",\"Sex\":\"F\"},{\"ID\":3,\"FName\":\"Amber\",\"LName\":\"Agar\",\"DOB\":\"12/23/1971\",\"Sex\":\"M\"},{\"ID\":4,\"FName\":\"Kathy\",\"LName\":\"Berry\",\"DOB\":\"11/15/1976\",\"Sex\":\"F\"},{\"ID\":5,\"FName\":\"Lena\",\"LName\":\"Bilton\",\"DOB\":\"05/11/1978\",\"Sex\":\"F\"},{\"ID\":6,\"FName\":\"Susanne\",\"LName\":\"Buck\",\"DOB\":\"03/7/1965\",\"Sex\":\"F\"},{\"ID\":7,\"FName\":\"Jim\",\"LName\":\"Brown\",\"DOB\":\"09/11/1972\",\"Sex\":\"M\"},{\"ID\":8,\"FName\":\"Jane\",\"LName\":\"Hooks\",\"DOB\":\"12/11/1972\",\"Sex\":\"F\"},{\"ID\":9,\"FName\":\"Robert\",\"LName\":\"\",\"DOB\":\"06/28/1964\",\"Sex\":\"M\"},{\"ID\":10,\"FName\":\"Cindy\",\"LName\":\"Fox\",\"DOB\":\"01/11/1978\",\"Sex\":\"M\"}]}";

            //if json is array then append the root element {"root": []}. below is wrong format, error will throw.
            //string jsInput = "[{\"ID\":1,\"FName\":\"John\",\"LName\":\"Shields\",\"DOB\":\"12/11/1971\",\"Sex\":\"M\"},{\"ID\":2,\"FName\":\"Mary\",\"LName\":\"Jacobs\",\"DOB\":\"01/17/1961\",\"Sex\":\"F\"},{\"ID\":3,\"FName\":\"Amber\",\"LName\":\"Agar\",\"DOB\":\"12/23/1971\",\"Sex\":\"M\"},{\"ID\":4,\"FName\":\"Kathy\",\"LName\":\"Berry\",\"DOB\":\"11/15/1976\",\"Sex\":\"F\"},{\"ID\":5,\"FName\":\"Lena\",\"LName\":\"Bilton\",\"DOB\":\"05/11/1978\",\"Sex\":\"F\"},{\"ID\":6,\"FName\":\"Susanne\",\"LName\":\"Buck\",\"DOB\":\"03/7/1965\",\"Sex\":\"F\"},{\"ID\":7,\"FName\":\"Jim\",\"LName\":\"Brown\",\"DOB\":\"09/11/1972\",\"Sex\":\"M\"},{\"ID\":8,\"FName\":\"Jane\",\"LName\":\"Hooks\",\"DOB\":\"12/11/1972\",\"Sex\":\"F\"},{\"ID\":9,\"FName\":\"Robert\",\"LName\":\"\",\"DOB\":\"06/28/1964\",\"Sex\":\"M\"},{\"ID\":10,\"FName\":\"Cindy\",\"LName\":\"Fox\",\"DOB\":\"01/11/1978\",\"Sex\":\"M\"}]";

            /*
             * Deserialize Json to XML
             */
            /**/
            //Type#1 using System.Xml.Linq XDocument
            Console.WriteLine("Deserialize Json to XML.Type#1 using System.Xml.Linq XDocument\n");
            XDocument xNodeFrJson = JsonConvert.DeserializeXNode(jsInput, "Employees");
            Console.WriteLine(xNodeFrJson);
            Console.WriteLine("====================================Deserialize Json to XML END===================\n");

            //Type#2 using System.Xml XmlDocument
            Console.WriteLine("Deserialize Json to XML.Type#2 using System.Xml XmlDocument\n");
            XmlDocument xmlFrJson = JsonConvert.DeserializeXmlNode(jsInput, "Employees");
            Console.WriteLine(xmlFrJson.InnerXml);
            Console.WriteLine("====================================Deserialize Json to XML END===================\n");

            /*
             * Serialize XML to Json
             */
            //Type#1 using System.Xml.Linq XDocument as input
            Console.WriteLine("Serialize XML to Json.Type#1 using System.Xml.Linq XDocument as input\n");
            string jsonFrXMLType1 = JsonConvert.SerializeXNode(xNodeFrJson);
            Console.WriteLine(jsonFrXMLType1);
            Console.WriteLine("====================================Serialize XML to Json END===================\n");

            //Type#2 using System.Xml XmlDocument as input
            Console.WriteLine("Serialize XML to Json.Type#2 using System.Xml XmlDocument as input\n");
            string jsonFrXMLType2 = JsonConvert.SerializeXmlNode(xmlFrJson);
            Console.WriteLine(jsonFrXMLType2);
            Console.WriteLine("====================================Serialize XML to Json END===================\n");
        }

        /// <summary>
        /// DataTable Json Conversion
        /// </summary>
        private static void DataTableJsonConversion()
        {
            DataTable objDt = new DataTable();
            objDt.TableName = "Employee";
            objDt.Columns.Add("ID");
            objDt.Columns.Add("FName");
            objDt.Columns.Add("LName");
            objDt.Columns.Add("DOB");
            objDt.Columns.Add("Sex");

            objDt.Rows.Add(new object[] { "1", "John", "Shields", DateTime.Parse("12/11/1971"), 'M' });
            objDt.Rows.Add(new object[] { "2", "Mary", "Jacobs", DateTime.Parse("01/17/1961"), 'F' });
            objDt.Rows.Add(new object[] { "3", "Amber", "Agar", DateTime.Parse("12/23/1971"), 'M' });
            objDt.Rows.Add(new object[] { "4", "Kathy", "Berry", DateTime.Parse("11/15/1976"), 'F' });
            objDt.Rows.Add(new object[] { "5", "Lena", "Bilton", DateTime.Parse("05/11/1978"), 'F' });
            objDt.Rows.Add(new object[] { "6", "Susanne", "Buck", DateTime.Parse("03/7/1965"), 'F' });
            objDt.Rows.Add(new object[] { "7", "Jim", "Brown", DateTime.Parse("09/11/1972"), 'M' });
            objDt.Rows.Add(new object[] { "8", "Jane", "Hooks", DateTime.Parse("12/11/1972"), 'F' });
            objDt.Rows.Add(new object[] { "9", "Robert", "", DateTime.Parse("06/28/1964"), 'M' });
            objDt.Rows.Add(new object[] { "10", "Cindy", "Fox", DateTime.Parse("01/11/1978"), 'M' });

            /* 
           * Serialize DataTableToJson
           */
            Console.WriteLine("Serialize DataTable To Json\n");
            string jsonFrDataTable = JsonConvert.SerializeObject(objDt, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(jsonFrDataTable);
            Console.WriteLine("====================================Serialize DataTable To Json END===================\n");

            /* 
            * Deserialize JsonToDataTable
            */
            Console.WriteLine("Deserialize Json To DataTable\n");
            DataTable dtJson = JsonConvert.DeserializeObject<DataTable>(jsonFrDataTable);


            foreach (DataRow emp in dtJson.Rows)
            {
                Console.WriteLine("ID:" + Utils.ToInteger(emp["ID"]));
                Console.WriteLine("FName:" + Utils.ToString(emp["FName"]));
                Console.WriteLine("LName:" + Utils.ToString(emp["LName"]));
                Console.WriteLine("DOB:" + Utils.ToString(emp["DOB"]));
                Console.WriteLine("Sex:" + Utils.ToString(emp["Sex"]));
                Console.WriteLine("\n");
            }
            Console.WriteLine("====================================Deserialize Json To DataTable END===================\n");

        }

        /// <summary>
        /// DataSet Json Conversion
        /// </summary>
        private static void DataSetJsonConversion()
        {
            DataSet objDS = new DataSet();

            DataTable objDt = new DataTable();
            objDt.TableName = "Employee";
            objDt.Columns.Add("ID");
            objDt.Columns.Add("FName");
            objDt.Columns.Add("LName");
            objDt.Columns.Add("DOB");
            objDt.Columns.Add("Sex");

            objDt.Rows.Add(new object[] { "1", "John", "Shields", DateTime.Parse("12/11/1971"), 'M' });
            objDt.Rows.Add(new object[] { "2", "Mary", "Jacobs", DateTime.Parse("01/17/1961"), 'F' });
            objDt.Rows.Add(new object[] { "3", "Amber", "Agar", DateTime.Parse("12/23/1971"), 'M' });
            objDt.Rows.Add(new object[] { "4", "Kathy", "Berry", DateTime.Parse("11/15/1976"), 'F' });
            objDt.Rows.Add(new object[] { "5", "Lena", "Bilton", DateTime.Parse("05/11/1978"), 'F' });
            objDt.Rows.Add(new object[] { "6", "Susanne", "Buck", DateTime.Parse("03/7/1965"), 'F' });
            objDt.Rows.Add(new object[] { "7", "Jim", "Brown", DateTime.Parse("09/11/1972"), 'M' });
            objDt.Rows.Add(new object[] { "8", "Jane", "Hooks", DateTime.Parse("12/11/1972"), 'F' });
            objDt.Rows.Add(new object[] { "9", "Robert", "", DateTime.Parse("06/28/1964"), 'M' });
            objDt.Rows.Add(new object[] { "10", "Cindy", "Fox", DateTime.Parse("01/11/1978"), 'M' });

            objDS.Tables.Add(objDt);


            /* 
            * Serialize DatasetToJson
            */
            Console.WriteLine("Serialize Dataset To Json\n");
            string jsonFrDataSet = JsonConvert.SerializeObject(objDS, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(jsonFrDataSet);
            Console.WriteLine("====================================Serialize Dataset To Json END===================\n");

            /* 
            * Deserialize JsonToDataset
            */
            Console.WriteLine("Deserialize Json To Dataset\n");
            DataSet dsJson = JsonConvert.DeserializeObject<DataSet>(jsonFrDataSet);


            foreach (DataRow emp in dsJson.Tables[0].Rows)
            {
                Console.WriteLine("ID:" + Utils.ToInteger(emp["ID"]));
                Console.WriteLine("FName:" + Utils.ToString(emp["FName"]));
                Console.WriteLine("LName:" + Utils.ToString(emp["LName"]));
                Console.WriteLine("DOB:" + Utils.ToString(emp["DOB"]));
                Console.WriteLine("Sex:" + Utils.ToString(emp["Sex"]));
                Console.WriteLine("\n");
            }
            Console.WriteLine("====================================Deserialize Json To Dataset END===================\n");
        }


        /// <summary>
        /// List Json Conversion
        /// </summary>
        private static void ListJsonConversion()
        {
            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee() { ID = 1, FName = "John", LName = "Shields", DOB = DateTime.Parse("12/11/1971"), Sex = 'M' });
            empList.Add(new Employee() { ID = 2, FName = "Mary", LName = "Jacobs", DOB = DateTime.Parse("01/17/1961"), Sex = 'F' });
            empList.Add(new Employee() { ID = 3, FName = "Amber", LName = "Agar", DOB = DateTime.Parse("12/23/1971"), Sex = 'M' });
            empList.Add(new Employee() { ID = 4, FName = "Kathy", LName = "Berry", DOB = DateTime.Parse("11/15/1976"), Sex = 'F' });
            empList.Add(new Employee() { ID = 5, FName = "Lena", LName = "Bilton", DOB = DateTime.Parse("05/11/1978"), Sex = 'F' });
            empList.Add(new Employee() { ID = 6, FName = "Susanne", LName = "Buck", DOB = DateTime.Parse("03/7/1965"), Sex = 'F' });
            empList.Add(new Employee() { ID = 7, FName = "Jim", LName = "Brown", DOB = DateTime.Parse("09/11/1972"), Sex = 'M' });
            empList.Add(new Employee() { ID = 8, FName = "Jane", LName = "Hooks", DOB = DateTime.Parse("12/11/1972"), Sex = 'F' });
            empList.Add(new Employee() { ID = 9, FName = "Robert", LName = "", DOB = DateTime.Parse("06/28/1964"), Sex = 'M' });
            empList.Add(new Employee() { ID = 10, FName = "Cindy", LName = "Fox", DOB = DateTime.Parse("01/11/1978"), Sex = 'M' });

            /* 
             * Serialize ListToJson
             */
            Console.WriteLine("Serialize List To Json\n");
            string jsonFrList = JsonConvert.SerializeObject(empList, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(jsonFrList);
            Console.WriteLine("====================================List To Json END===================\n");

            /* 
             * Deserialize JsonToList
             */
            Console.WriteLine("Deserialize Json To List\n");
            List<Employee> empListFrJson = JsonConvert.DeserializeObject<List<Employee>>(jsonFrList);

            foreach (var emp in empListFrJson)
            {
                Console.WriteLine("ID:" + emp.ID);
                Console.WriteLine("FName:" + emp.FName);
                Console.WriteLine("LName:" + emp.LName);
                Console.WriteLine("DOB:" + emp.DOB);
                Console.WriteLine("Sex:" + emp.Sex);
                Console.WriteLine("\n");
            }

            Console.WriteLine("====================================Json To List END===================\n");
            //Console.ReadLine();
        }
    }


   
}
