using UnityEngine;

public class ConverterMod : Converter
{
	private PlaySound m_PlaySound;

	private Vector2Int TopLeft = new Vector2Int(0, -1);

	private Vector2Int BottomRight = new Vector2Int(1, 0);

	private Vector2Int AccessPoint = new Vector2Int(-1, 0);

	private Vector2Int SpawnPoint = new Vector2Int(2, 0);

	private Vector3 StartScale = new Vector3(-1f, 1f, 1f);

	public override void Restart()
	{
		base.Restart();
		Vector3 Scale;
		ModManager.Instance.ModConverterClass.GetModelScale(m_TypeIdentifier, out Scale);
		m_ModelRoot.transform.localScale = new Vector3(Scale.x, Scale.y, Scale.z);
		StartScale = Scale;
		Vector3 Rot;
		if (ModManager.Instance.ModConverterClass.GetModelRotation(m_TypeIdentifier, out Rot))
		{
			m_ModelRoot.transform.localRotation = Quaternion.Euler(Rot.x, Rot.y, Rot.z);
		}
		Vector3 Trans;
		if (ModManager.Instance.ModConverterClass.GetModelTranslation(m_TypeIdentifier, out Trans))
		{
			m_ModelRoot.transform.localPosition = new Vector3(Trans.x, Trans.y, Trans.z);
		}
		m_DisplayIngredients = true;
		ModManager.Instance.ModConverterClass.ModCoordsTL.TryGetValue(m_TypeIdentifier, out TopLeft);
		ModManager.Instance.ModConverterClass.ModCoordsBR.TryGetValue(m_TypeIdentifier, out BottomRight);
		ModManager.Instance.ModConverterClass.ModCoordsAccess.TryGetValue(m_TypeIdentifier, out AccessPoint);
		ModManager.Instance.ModConverterClass.ModCoordsSpawn.TryGetValue(m_TypeIdentifier, out SpawnPoint);
		SetDimensions(new TileCoord(TopLeft.x, TopLeft.y), new TileCoord(BottomRight.x, BottomRight.y), new TileCoord(AccessPoint.x, AccessPoint.y));
		SetSpawnPoint(new TileCoord(SpawnPoint.x, SpawnPoint.y));
	}

	public override void StartConverting()
	{
		base.StartConverting();
		m_PlaySound = AudioManager.Instance.StartEvent("BuildingWorkbenchMaking", this, true);
	}

	protected override void UpdateConverting()
	{
		if ((int)(m_StateTimer * 60f) % 20 < 10)
		{
			m_ModelRoot.transform.localScale = new Vector3(StartScale.x * 0.9f, StartScale.y * 1.3f, StartScale.z * 0.9f);
		}
		else
		{
			m_ModelRoot.transform.localScale = new Vector3(StartScale.x, StartScale.y, StartScale.z);
		}
		UpdateConvertAnimTimer(0.33f);
	}

	protected override void EndConverting()
	{
		AudioManager.Instance.StopEvent(m_PlaySound);
		AudioManager.Instance.StartEvent("BuildingToolMakingComplete", this);
		ModManager.Instance.CheckCustomCallback(ModManager.CallbackTypes.ConverterComplete, m_TypeIdentifier, m_TileCoord, -1, m_UniqueID);
		m_ModelRoot.transform.localScale = new Vector3(StartScale.x, StartScale.y, StartScale.z);
	}

	public override void DoConvertAnimAction()
	{
		base.DoConvertAnimAction();
		UpdateIngredients();
	}
}
