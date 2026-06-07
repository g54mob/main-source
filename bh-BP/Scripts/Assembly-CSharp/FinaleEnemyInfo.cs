public struct FinaleEnemyInfo
{
	public float Theta;

	public float Radius;

	public float ThetaSpeed;

	public float LocalRot;

	public float RotSpeed;

	public FinaleEnemyInfo(float t, float r, float s)
	{
		Theta = 0f;
		Radius = 0f;
		ThetaSpeed = 0f;
		LocalRot = 0f;
		RotSpeed = 0f;
	}

	public FinaleEnemyInfo(FinaleEnemyInfo f)
	{
		Theta = 0f;
		Radius = 0f;
		ThetaSpeed = 0f;
		LocalRot = 0f;
		RotSpeed = 0f;
	}
}
