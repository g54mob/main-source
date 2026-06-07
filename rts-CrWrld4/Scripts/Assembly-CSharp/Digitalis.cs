public class Digitalis
{
	public const int MAX_HEALTH = 1000000;

	public const int GROWTH_TIME = 1000000;

	private const int GROWTH_RATE = 20000;

	private const int HEAL_RATE = 20000;

	private const int WITHER_RATE = 2000;

	public const int DAMAGE_COLOR0 = 1000000;

	public const int DAMAGE_COLOR1 = 750000;

	public const int DAMAGE_COLOR2 = 1;

	public int[] digitalisData;

	public bool[] growthData;

	private bool[] connected;

	private int[] shadow;

	public void Init()
	{
	}

	public void GameUpdate()
	{
	}

	public void MarkForRefresh(int x, int y)
	{
	}

	private void UpdateDigitalis()
	{
	}

	private void FloodFillConnectedOnly(int start)
	{
	}

	private void UpdateConnected()
	{
	}

	public void AddGrowthSpot(int gsx, int gsy, bool overwriteDigitalis = true)
	{
	}

	public void RemoveGrowthSpot(int gsx, int gsy, bool overwriteDigitalis = true)
	{
	}

	public bool GetGrowthSpot(int gsx, int gsy)
	{
		return false;
	}

	public int GetDigitalis(int gsx, int gsy)
	{
		return 0;
	}

	public int GetDigitalisRaw(int gsx, int gsy)
	{
		return 0;
	}

	public void SetDigitalisRaw(int gsx, int gsy, int val)
	{
	}

	public void CreateDigitalis(int gsx, int gsy)
	{
	}

	public void Damage(int gsx, int gsy, int damageAmt, int r)
	{
	}

	public void Damage(int gsx, int gsy, int damageAmt, int r, bool suppressMVerse)
	{
	}

	public void Damage(int gsx, int gsy, int damageAmt)
	{
	}

	public void ClearAllLiveDigitalis()
	{
	}

	public void CompleteAllLiveDigitalis()
	{
	}

	public void ResizeMap(int newWidth, int newHeight)
	{
	}
}
