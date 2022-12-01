
namespace SpeedText
{
    internal class Data
    {
        string name;
        int simbols_per_minute;
        int simbols_per_second;
        public Data(string n,int s_p_m, int s_p_s)
        {
            name = n;
            simbols_per_minute = s_p_m;
            simbols_per_second = s_p_s;
        }
    }
}
