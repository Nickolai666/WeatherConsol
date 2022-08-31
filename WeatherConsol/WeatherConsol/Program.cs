using Npgsql;
using System.Collections.ObjectModel;
using System.Net;
using System.Text.Json;
using System.Xml.Serialization;
using static System.Console;

namespace WeatherConsol
{
    //Классы

    public class UserApi
    {
        public string UserApiProperty { get; set; }
    }


    //(Начало)Определяем класс RootBasicCityInfo
    public class Region
    {
        public string ID { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
    }

    public class Country
    {
        public string ID { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
    }

    public class AdministrativeArea
    {
        public string ID { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
        public int Level { get; set; }
        public string LocalizedType { get; set; }
        public string EnglishType { get; set; }
        public string CountryID { get; set; }
    }

    public class TimeZone
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double GmtOffset { get; set; }
        public bool IsDaylightSaving { get; set; }
        public object NextOffsetChange { get; set; }
    }

    //(Начало)Определяем класс GeoPosition
    //(Начало)Определяем класс Elevation
    public class Metric
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Imperial
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Elevation
    {
        public Metric Metric { get; set; }
        public Imperial Imperial { get; set; }
    }
    //(Конец)Определяем класс Elevation

    public class GeoPosition
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Elevation Elevation { get; set; }
    }
    //(Начало)Определяем класс GeoPosition


    public class SupplementalAdminArea
    {
        public int Level { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
    }

    public class RootBasicCityInfo
    {
        public int Version { get; set; }
        public string Key { get; set; }
        public string Type { get; set; }
        public int Rank { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
        public string PrimaryPostalCode { get; set; }
        public Region Region { get; set; }
        public Country Country { get; set; }
        public AdministrativeArea AdministrativeArea { get; set; }
        public TimeZone TimeZone { get; set; }
        public GeoPosition GeoPosition { get; set; }
        public bool IsAlias { get; set; }
        public List<SupplementalAdminArea> SupplementalAdminAreas { get; set; }
        public List<string> DataSets { get; set; }
    }
    //(Конец)Определяем класс RootBasicCityInfo

    public class CitiesFromDB
    {
        public int Id { get; set; }
        public string Key { get; set; }
        public string LocalizedName { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string AdministrativeArea { get; set; }
    }

    //(Начало)Определяем класс DailyForecast
    public class Sun
    {
        public DateTime Rise { get; set; }
        public int EpochRise { get; set; }
        public DateTime Set { get; set; }
        public int EpochSet { get; set; }
    }

    public class Moon
    {
        public DateTime Rise { get; set; }
        public int EpochRise { get; set; }
        public DateTime Set { get; set; }
        public int EpochSet { get; set; }
        public string Phase { get; set; }
        public int Age { get; set; }
    }

    //(Начало)Определяем класс Temperature
    public class Minimum
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Maximum
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Temperature
    {
        public Minimum Minimum { get; set; }
        public Maximum Maximum { get; set; }
    }
    //(Конец)Определяем класс Temperature

    //(Начало)Определяем класс RealFeelTemperature
    public class Minimum_RFT
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
        public string Phrase { get; set; }
    }

    public class Maximum_RFT
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
        public string Phrase { get; set; }
    }

    public class Temperature_RFT
    {
        public Minimum_RFT Minimum_RFT { get; set; }
        public Maximum_RFT Maximum_RFT { get; set; }
    }
    //(Конец)Определяем класс RealFeelTemperature


    //(Начало)Определяем класс RealFeelTemperatureShade
    public class Temperature_RFTS
    {
        public Minimum_RFT Minimum_RFT { get; set; }
        public Maximum_RFT Maximum_RFT { get; set; }
    }
    //(Конец)Определяем класс RealFeelTemperatureShade

    //(Начало)Определяем класс DegreeDaySummary
    public class Heating
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Cooling
    {
        public double Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class DegreeDaySummary
    {
        public Heating Heating { get; set; }
        public Cooling Cooling { get; set; }
    }
    //(Конец)Определяем класс DegreeDaySummary

    public class AirAndPollen
    {
        public string Name { get; set; }
        public int Value { get; set; }
        public string Category { get; set; }
        public int CategoryValue { get; set; }
        public string Type { get; set; }
    }

    //(Начало)Определяем класс Day
    //(Начало)Определяем класс Wind
    public class Speed
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Direction
    {
        public int Degrees { get; set; }
        public string Localized { get; set; }
        public string English { get; set; }
    }

    public class Wind
    {
        public Speed Speed { get; set; }
        public Direction Direction { get; set; }
    }
    //(Конец)Определяем класс Wind

    //(Начало)Определяем класс Windgust
    public class Speed_WG
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Direction_WG
    {
        public int Degrees { get; set; }
        public string Localized { get; set; }
        public string English { get; set; }
    }

    public class Windgust
    {
        public Speed_WG Speed_WG { get; set; }
        public Direction_WG Direction_WG { get; set; }
    }
    //(Конец)Определяем класс Windgust

    public class Totalliquid
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Rain
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Snow
    {
        public float value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Ice
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Evapotranspiration
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class SolarIrradiance
    {
        public float Value { get; set; }
        public string Unit { get; set; }
        public int UnitType { get; set; }
    }

    public class Day
    {
        public int Icon { get; set; }
        public string IconPhrase { get; set; }
        public bool HasPrecipitation { get; set; }
        public string ShortPhrase { get; set; }
        public string LongPhrase { get; set; }
        public int PrecipitationProbability { get; set; }
        public int ThunderstormProbability { get; set; }
        public int RainProbability { get; set; }
        public int SnowProbability { get; set; }
        public int IceProbability { get; set; }
        public Wind Wind { get; set; }
        public Windgust WindGust { get; set; }
        public Totalliquid TotalLiquid { get; set; }
        public Rain Rain { get; set; }
        public Snow Snow { get; set; }
        public Ice Ice { get; set; }
        public float HoursOfPrecipitation { get; set; }
        public float HoursOfRain { get; set; }
        public float HoursOfSnow { get; set; }
        public float HoursOfIce { get; set; }
        public int CloudCover { get; set; }
        public Evapotranspiration Evapotranspiration { get; set; }
        public SolarIrradiance SolarIrradiance { get; set; }
        public string PrecipitationType { get; set; }
        public string PrecipitationIntensity { get; set; }
    }
    //(Конец)Определяем класс Day


    //(Начало)Определяем класс Night
    public class Night
    {
        public int Icon { get; set; }
        public string IconPhrase { get; set; }
        public bool HasPrecipitation { get; set; }
        public string ShortPhrase { get; set; }
        public string LongPhrase { get; set; }
        public int PrecipitationProbability { get; set; }
        public int ThunderstormProbability { get; set; }
        public int RainProbability { get; set; }
        public int SnowProbability { get; set; }
        public int IceProbability { get; set; }
        public Wind Wind { get; set; }
        public Windgust WindGust { get; set; }
        public Totalliquid TotalLiquid { get; set; }
        public Rain Rain { get; set; }
        public Snow Snow { get; set; }
        public Ice Ice { get; set; }
        public float HoursOfPrecipitation { get; set; }
        public float HoursOfRain { get; set; }
        public float HoursOfSnow { get; set; }
        public float HoursOfIce { get; set; }
        public int CloudCover { get; set; }
        public Evapotranspiration Evapotranspiration { get; set; }
        public SolarIrradiance SolarIrradiance { get; set; }
        public string PrecipitationType { get; set; }
        public string PrecipitationIntensity { get; set; }
    }
    //(Конец)Определяем класс Night

    public class DailyForecast
    {
        public DateTime Date { get; set; }
        public int EpochDate { get; set; }
        public Sun Sun { get; set; }
        public Moon Moon { get; set; }
        public Temperature Temperature { get; set; }
        public Temperature_RFT Temperature_RFT { get; set; }
        public Temperature_RFTS Temperature_RFTS { get; set; }
        public double HoursOfSun { get; set; }
        public DegreeDaySummary DegreeDaySummary { get; set; }
        public AirAndPollen[] AirAndPollen { get; set; }
        public Day Day { get; set; }
        public Night Night { get; set; }
        public List<string> Sources { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
    }
    //(Конец)Определяем класс DailyForecast


    //(Начало)Определяем класс RootWeather
    public class Headline
    {
        public DateTime EffectiveDate { get; set; }
        public int EffectiveEpochDate { get; set; }
        public int Severity { get; set; }
        public string Text { get; set; }
        public string Category { get; set; }
        public DateTime EndDate { get; set; }
        public int EndEpochDate { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
    }

    public class RootWeather
    {
        public Headline Headline { get; set; }
        public List<DailyForecast> DailyForecasts { get; set; }
    }
    //(Конец)Определяем класс RootWeather


    //(Начало)Класс для подключения к БД PostgreSql
    static class UtilsPostgres
    {
        public static NpgsqlConnection Connect(string connectionString)
        {
            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                throw new Exception("Error connecting to the database", e);
            }
            return conn;
        }

        public static async Task ExecuteSql(NpgsqlConnection conn, string sql)
        {
            try
            {
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = sql;
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
            }
        }

        public static async Task ExecuteSelectAsJson(NpgsqlConnection conn, string sql, Action<string> callback)
        {
            try
            {
                using (var command = conn.CreateCommand())
                {
                    command.CommandText = sql;
                    var result = command.ExecuteScalar();
                    if (result is string json)
                    {
                        callback(json);
                    }
                }
            }
            catch (Exception e)
            {
            }
        }
    }
    //(Конец)Класс для подключения к БД PostgreSql

    class Program
    {       
        //--------------//
        //Методы(Начало)//
        //--------------//

        // Метод реализует возможность получать вывод списка городов из справочника БД PostgreSql
        public static void ReadListOfCityМonitoring()
        {
            // connect
            string connectionString = "Server=localhost; Port=5432; Database=postgres; UserId=postgres; Password=admin; commandTimeout=120;";
            var conn = UtilsPostgres.Connect(connectionString);

            // getting data
            string sql = $@"
                                   SELECT json_agg(row_to_json(cities))
                                   FROM
                                   (
                                        SELECT ""Id""
	                                         , ""Key""
	                                         , ""LocalizedName""
	                                         , ""Region""
	                                         , ""Country""
	                                         , ""AdministrativeArea""
                                          FROM public.""CitiesForWeatherForecast""
                                   ) AS cities;
                              ";

            UtilsPostgres.ExecuteSelectAsJson
                (conn, sql, json =>
                {
                    // convert jsobn to list
                    ObservableCollection<CitiesFromDB> cfdb = JsonSerializer.Deserialize<ObservableCollection<CitiesFromDB>>(json);

                    // show list
                    WriteLine();
                    PrintLine();
                    PrintRow("Id", "Key", "City");
                    PrintLine();
                    foreach (var item in cfdb)
                    {
                        PrintRow(Convert.ToString(item.Id), item.Key, item.LocalizedName);
                        PrintLine();
                    }
                }
                );
        }

        // Метод реализует возможность отображать список запрашиваемых городов
        public static void PrintReceivedСities(ObservableCollection<RootBasicCityInfo> formalListOfCityes)
        {
            string pattern =
                "=====\n" +
                "Номер в списке: {0}\n" +
                "Название в оригинале: {1}\n" +
                "В переводе:  {2} \n" +
                "Страна: {3}\n" +
                "Административный округ: {4}\n" +
                "Тип: {5}\n" + "====\n";

            int numberInList = 0;

            foreach (var item in formalListOfCityes)
            {
                WriteLine
                       (
                          pattern
                        , numberInList.ToString()
                        , item.EnglishName
                        , item.LocalizedName
                        , item.Country.LocalizedName
                        , item.AdministrativeArea.LocalizedName
                        , item.AdministrativeArea.LocalizedType
                       );

                //Добавляем город в справочник public."CitiesForWeatherForecast" БД PostgreSql при условии, что его там нет
                string connectionString = "Server=localhost; Port=5432; Database=postgres; UserId=postgres; Password=admin; commandTimeout=120;";
                var conn = UtilsPostgres.Connect(connectionString);

                string sql =
                    "do $$" +
                    "   declare cnt integer;" +
                    "   begin" +
                    "       select count(\"Key\")" +
                    "         into cnt" +
                    "         from public.\"CitiesForWeatherForecast\"" +
                    "        where \"Key\" = '" + item.Key + "';" +
                    "" +
                    "       if cnt = 0 then " +
                    "           insert into public.\"CitiesForWeatherForecast\" " +
                    "               (" +
                    "                   \"Version\" " +
                    "                 , \"Key\" " +
                    "                 , \"Type\" " +
                    "                 , \"Rank\" " +
                    "                 , \"LocalizedName\" " +
                    "                 , \"EnglishName\" , " +
                    "                   \"PrimaryPostalCode\" " +
                    "                 , \"Region\" " +
                    "                 , \"Country\" , " +
                    "                   \"AdministrativeArea\" " +
                    "                 , \"TimeZoneName\" " +
                    "                 , \"TimeZoneGmtOffset\" " +
                    "                 , \"GeoPositionLatitude\" " +
                    "                 , \"GeoPositionLongitude\" , " +
                    "                   \"GeoPositionElevationMetric\" " +
                    "                 , \"GeoPositionElevationImperial\" " +
                    "                 , \"IsAlias\" " +
                    "               ) " +
                    "           VALUES " +
                    "               ( " +
                                        item.Version + ", '" +
                                        item.Key + "', '" +
                                        item.Type + "', " +
                                        item.Rank + ", '" +
                                        item.LocalizedName + "', '" +
                                        item.EnglishName + "', '" +
                                        item.PrimaryPostalCode + "', '" +
                                        item.Region.LocalizedName + "', '" +
                                        item.Country.LocalizedName + "', '" +
                                        item.AdministrativeArea.LocalizedType + "', '" +
                                        item.TimeZone.Name + "', " +
                                        Convert.ToString(item.TimeZone.GmtOffset).Replace(",", ".") + ", " +
                                        Convert.ToString(item.GeoPosition.Latitude).Replace(",", ".") + ", " +
                                        Convert.ToString(item.GeoPosition.Longitude).Replace(",", ".") + ", " +
                                        Convert.ToString(item.GeoPosition.Elevation.Metric.Value).Replace(",", ".") + ", " +
                                        Convert.ToString(item.GeoPosition.Elevation.Imperial.Value).Replace(",", ".") + ", " +
                                        item.IsAlias +
                                   ");" +
                    "       else " +
                    "           return;" +
                    "       end if; " +
                    "end $$;";
                UtilsPostgres.ExecuteSql(conn, sql);

                numberInList++;
            }

            ReadListOfCityМonitoring();
        }


        //(Начало)Методы для вывода данных в консоль
        static int tableWidth = 100;
        static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }

        static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }
        //(Конец)Методы для вывода данных в консоль


        //--------------//
        //Методы(Конец) //
        //--------------//


        //--------------//
        //Классы(Начало)//
        //--------------//

        // Класс описывает возможность чтения и записи пользовательского API
        public static class UserApiManager
        {
            // Список хранит APIKey
            public static ObservableCollection<UserApi> userApiList = new ObservableCollection<UserApi>();

            // Метод реализует возможность записи пользользовательского APIKey на диск
            public static void WriteUserApiToLocalStorage(string formalUserApi)
            {
                UserApi userApiProp = new UserApi
                {
                    UserApiProperty = formalUserApi
                };

                userApiList.Add(userApiProp);

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<UserApi>));

                using (StreamWriter sw = new StreamWriter("UserApi.xml"))
                {
                    xmlSerializer.Serialize(sw, userApiList);
                }
            }


            // Метод реализует возможность восстановления списка APIKey в памяти
            public static void ReadUserApiToLocalStorage()
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<UserApi>));

                try
                {
                    using (StreamReader sr = new StreamReader("UserApi.xml"))
                    {
                        userApiList = xmlSerializer.Deserialize(sr) as ObservableCollection<UserApi>;
                    }
                }

                catch (Exception ex)
                {
                    /* Не вывожу никаких сообщений об ошибке. Потому как, если утилита была запущена впервые
                    / то файла скорее всего нет. Даже если бы он был и из-за каких-то аппаратных проблем стал недоступен
                    / то что я могу с этим поделать в таком случае?
                    */
                }
            }
        }

        //Класс описывает возможность получения поиска и добавления городов для их последующего мониторинга.
        public static class SearchCity
        {
            // Метод реализует возможность получения списка городов с сайта по названию, введенному пользователем в MainMenu
            public static void GettingListOfCitiesOnRequest(string formalCityName)
            {
                // Получаю ApiKey из списка
                string apiKey = UserApiManager.userApiList[1].UserApiProperty;
                try
                {
                    string jsonOnWeb = $"http://dataservice.accuweather.com/locations/v1/cities/search?apikey={apiKey}&q={formalCityName}";

                    WebClient webClient = new WebClient();
                    string prepareString = webClient.DownloadString(jsonOnWeb);

                    //string prepareString = "[{\"Version\":1,\"Key\":\"294459\",\"Type\":\"City\",\"Rank\":21,\"LocalizedName\":\"Novosibirsk\",\"EnglishName\":\"Novosibirsk\",\"PrimaryPostalCode\":\"\",\"Region\":{\"ID\":\"ASI\",\"LocalizedName\":\"Asia\",\"EnglishName\":\"Asia\"},\"Country\":{\"ID\":\"RU\",\"LocalizedName\":\"Russia\",\"EnglishName\":\"Russia\"},\"AdministrativeArea\":{\"ID\":\"NVS\",\"LocalizedName\":\"Novosibirsk\",\"EnglishName\":\"Novosibirsk\",\"Level\":1,\"LocalizedType\":\"Oblast\",\"EnglishType\":\"Oblast\",\"CountryID\":\"RU\"},\"TimeZone\":{\"Code\":\"NOVT\",\"Name\":\"Asia/Novosibirsk\",\"GmtOffset\":7.0,\"IsDaylightSaving\":false,\"NextOffsetChange\":null},\"GeoPosition\":{\"Latitude\":55.028,\"Longitude\":82.923,\"Elevation\":{\"Metric\":{\"Value\":143.0,\"Unit\":\"m\",\"UnitType\":5},\"Imperial\":{\"Value\":469.0,\"Unit\":\"ft\",\"UnitType\":0}}},\"IsAlias\":false,\"SupplementalAdminAreas\":[{\"Level\":2,\"LocalizedName\":\"Novosibirsk City\",\"EnglishName\":\"Novosibirsk City\"}],\"DataSets\":[\"AirQualityCurrentConditions\",\"AirQualityForecasts\",\"Alerts\",\"ForecastConfidence\",\"FutureRadar\",\"MinuteCast\"]}]";

                    ObservableCollection<RootBasicCityInfo> rbci = JsonSerializer.Deserialize<ObservableCollection<RootBasicCityInfo>>(prepareString);

                    PrintReceivedСities(rbci);
                }
                catch (Exception ex)
                {
                    WriteLine("Неполучилось отобразить запрашиваемый город."
                    + "Возможные причины: \n" +
                    "* Неправильно указано название города\n"
                    + "* Нет доступа к интернету\n"
                    + "Подробнее ниже: \n"
                    + ex.Message);
                }

            }
        }

        //Класс описывает полученные результаты о прогнозе погоды
        public static class GettingWeatherData
        {
            // Метод реализует возможность получать погодную информацию выбранного города
            public static void GettingWeatherDataFromServices()
            {
                ReadListOfCityМonitoring();

                int num = 0;
                Write("Номер города для просмотра погоды Id: ");
                num = Convert.ToInt32(Console.ReadLine());

                // connect
                string connectionString = "Server=localhost; Port=5432; Database=postgres; UserId=postgres; Password=admin; commandTimeout=120;";
                var conn = UtilsPostgres.Connect(connectionString);

                // getting data
                string sql = $@"
                                   SELECT json_agg(row_to_json(cities))
                                   FROM
                                   (
                                        SELECT ""Id""
	                                         , ""Key""
	                                         , ""LocalizedName""
	                                         , ""Region""
	                                         , ""Country""
	                                         , ""AdministrativeArea""
                                          FROM public.""CitiesForWeatherForecast""
                                   ) AS cities;
                              ";

                UtilsPostgres.ExecuteSelectAsJson(conn, sql, json => {

                    // convert jsobn to list
                    ObservableCollection<CitiesFromDB> cfdb = JsonSerializer.Deserialize<ObservableCollection<CitiesFromDB>>(json);

                    //Проверяем, что введенный Id города содержится в справочнике. 
                    //Если содержится, то получем Key соответствующего города
                    int IsContain = 0;
                    string StrCityKey = ""; /*Ключ города для запроса на сайт*/
                    string CityName = ""; /*Название города для загрузки данных в хранилище*/

                    foreach (var item in cfdb)
                    {
                        if (item.Id == num)
                        {
                            IsContain = 1;
                            StrCityKey = item.Key;
                            CityName = item.LocalizedName;
                        }
                    }

                    if (IsContain == 0)
                    {
                        WriteLine("Такого номера нет. Попробуйте ещё раз.");
                    }
                    else
                    {
                        // Получаю ApiKey из списка
                        string apiKey = UserApiManager.userApiList[1].UserApiProperty;

                        WebClient webClient = new WebClient();
                        string jsonUrl = $"http://dataservice.accuweather.com/forecasts/v1/daily/5day/{StrCityKey}?apikey={apiKey}&language=ru&details=true&metric=true";
                        jsonUrl = webClient.DownloadString(jsonUrl);

                        RootWeather weatherData = JsonSerializer.Deserialize<RootWeather>(jsonUrl);

                        Console.Clear();
                        PrintLine();
                        PrintRow("City", "DtForecast", "TempMin", "TempMax", "LiqDay", "LiqNight", "WindSpDay", "WindSpNight");
                        PrintLine();
                        foreach (var item_forecast in weatherData.DailyForecasts)
                        {
                            PrintRow(
                                      CityName
                                    , Convert.ToString(item_forecast.Date)
                                    , Convert.ToString(item_forecast.Temperature.Minimum.Value)
                                    , Convert.ToString(item_forecast.Temperature.Maximum.Value)
                                    , Convert.ToString(item_forecast.Day.TotalLiquid.Value)
                                    , Convert.ToString(item_forecast.Night.TotalLiquid.Value)
                                    , Convert.ToString(item_forecast.Day.Wind.Speed.Value)
                                    , Convert.ToString(item_forecast.Night.Wind.Speed.Value)
                                    );
                            PrintLine();
                        }

                        Write("Загрузить данные в хранилище? Ваш выбор(y|n): ");
                        string answer2 = ReadLine();

                        switch (answer2)
                        {
                            case "y":
                                {
                                    //Загружаем данные о прогнозе погоды в таблицу public."WeatherForecast" БД PostgreSql
                                    string connectionString = "Server=localhost; Port=5432; Database=postgres; UserId=postgres; Password=admin; commandTimeout=120;";
                                    var conn = UtilsPostgres.Connect(connectionString);
                                    int cnt = weatherData.DailyForecasts.Count;

                                    foreach (var item_forecast in weatherData.DailyForecasts)
                                    {
                                        string sql =
                                        "           insert into public.\"WeatherForecast\" " +
                                        "               (" +
                                        "                   \"City\" " +
                                        "                 , \"DateForecast\" " +
                                        "                 , \"TemperatureMin\" " +
                                        "                 , \"TemperatureMax\" " +
                                        "                 , \"LiquidDay\" " +
                                        "                 , \"LiquidNight\" " +
                                        "                 , \"WindSpeedDay\" " +
                                        "                 , \"WindSpeedNight\" " +
                                        "                 , \"DLM\" " +
                                        "               ) " +
                                        "           VALUES " +
                                        "               ( '" +
                                                            CityName + "', '" +
                                                            item_forecast.Date + "', " +
                                                            Convert.ToString(item_forecast.Temperature.Minimum.Value).Replace(",", ".") + ", " +
                                                            Convert.ToString(item_forecast.Temperature.Maximum.Value).Replace(",", ".") + ", " +
                                                            Convert.ToString(item_forecast.Day.TotalLiquid.Value).Replace(",", ".") + ", " +
                                                            Convert.ToString(item_forecast.Night.TotalLiquid.Value).Replace(",", ".") + ", " +
                                                            Convert.ToString(item_forecast.Day.Wind.Speed.Value).Replace(",", ".") + ", " +
                                                            Convert.ToString(item_forecast.Night.Wind.Speed.Value).Replace(",", ".") + ", '" +
                                                            Convert.ToString(DateTime.Now) +
                                                        "');";
                                        UtilsPostgres.ExecuteSql(conn, sql);
                                    }
                                    Write("В таблицу public.\"WeatherForecast\" загружено " + Convert.ToString(cnt) + " строк");
                                    Write("");
                                }
                                break;

                            case "n":
                                {

                                };
                                break;

                            default:
                                {
                                    WriteLine("Что-то пошло не так");
                                }
                                break;
                        }
                    }
                });
            }
        }

        // Класс описывает главное меню для взаимодействия с программой.
        public static class MainMenu
        {
            public static void PrintMainMenu()
            {
                bool canExit = true;
                string answer = null;
                while (canExit)
                {
                    WriteLine();
                    WriteLine("==================================");
                    WriteLine("|Добро пожаловать в Погоду       |");
                    WriteLine("|Доступные действия:             |\n" +
                              "==================================");
                    WriteLine("|1 - Ввести API                  |\n" +
                              "|2 - Добавить город              |\n" +
                              "|3 - Посмотреть погоду           |\n" +
                              "|q - Выйти из программы          |");
                    WriteLine("===============================\n");

                    Write("Ваш выбор: ");
                    answer = ReadLine();

                    switch (answer)
                    {
                        case "1":
                            {
                                string api = ReadLine();
                                UserApiManager.WriteUserApiToLocalStorage(api);
                            }
                            break;

                        case "2":
                            {
                                Write("Введите название города(ru, en): ");
                                string nameOfCity = ReadLine();
                                SearchCity.GettingListOfCitiesOnRequest(nameOfCity);
                            }
                            break;

                        case "3":
                            {
                                GettingWeatherData.GettingWeatherDataFromServices();
                            }
                            break;

                        case "q":
                        case "Q":
                        case "й":
                        case "Й":
                            {
                                canExit = false;
                            }
                            break;

                        default:
                            {
                                WriteLine("Что-то пошло не так");
                            }
                            break;
                    }
                }
            }


        }

        //--------------//
        //Классы(Конец)//
        //--------------//

        // Основная процедура
        static void Main(string[] args)
        {
            // Загружаю пользовательский API
            UserApiManager.ReadUserApiToLocalStorage();

            // Печатаю меню
            MainMenu.PrintMainMenu();
        }
    }
}
