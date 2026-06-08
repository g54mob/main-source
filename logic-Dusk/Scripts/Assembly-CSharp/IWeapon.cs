public interface IWeapon
{
	void Arm();

	void Disarm();

	bool isArmed();

	bool isSaftey();

	void EngageSaftey(bool engageSaftey);
}
