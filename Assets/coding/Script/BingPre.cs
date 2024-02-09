using UnityEngine;

class BingPre
{
    private const string KEY_GOOD_USER = "bingo";
    public static bool isBingoClick()
    {
        int count = PlayerPrefs.GetInt(KEY_GOOD_USER, 0);
        return count > 0;
    }

    public static void SetBingo()
    {
        PlayerPrefs.SetInt(KEY_GOOD_USER, 8);

    }
}
