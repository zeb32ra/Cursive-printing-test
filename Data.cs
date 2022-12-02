
namespace SpeedText
{
    internal class Data
    {
        public string name;
        public int simbols_per_minute;
        public double simbols_per_second;
        public Data(string n,int s_p_m, double s_p_s)
        {
            name = n;
            simbols_per_minute = s_p_m;
            simbols_per_second = s_p_s;
        }
    }
}
