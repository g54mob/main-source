public class DamageLog
{
	public int time;

	public string player_attacked;

	public int damage;

	public string weapon_used;

	public DamageLog(int time, string player_attacked, int damage, string weapon_used)
	{
		this.time = time;
		this.player_attacked = player_attacked;
		this.damage = damage;
		this.weapon_used = weapon_used;
	}

	public override string ToString()
	{
		return $"{time}, '{player_attacked}', '{weapon_used}', {damage}";
	}
}
