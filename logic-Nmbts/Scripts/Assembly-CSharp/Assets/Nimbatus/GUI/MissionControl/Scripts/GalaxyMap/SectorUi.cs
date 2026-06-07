using System.Collections;
using Assets.Nimbatus.Scripts.GalaxyMap.Sectors;
using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionControl.Scripts.GalaxyMap
{
	public abstract class SectorUi<T> : MonoBehaviour where T : GalaxyMapSector
	{
		public MeshRenderer RevealBlob;

		public T Sector;

		public GalaxyMapUiManager Manager;

		public void Init(GalaxyMapUiManager manager, T sector)
		{
			Manager = manager;
			Sector = sector;
			if (Sector.Explored)
			{
				RevealBlob.material.SetColor("_TintColor", new Color(0f, 1f, 0f, 0.5f));
			}
			else if (Sector.Scanned)
			{
				RevealBlob.material.SetColor("_TintColor", new Color(0f, 1f, 0f, 0.11f));
			}
			else if (Sector.Revealed)
			{
				RevealBlob.material.SetColor("_TintColor", new Color(0f, 1f, 0f, 0.11f));
			}
			else
			{
				RevealBlob.material.SetColor("_TintColor", new Color(0f, 1f, 0f, 0.07f));
			}
			StartCoroutine(ScaleRevealBlob());
			Init();
		}

		public abstract void Init();

		public IEnumerator ScaleRevealBlob()
		{
			float num = (Sector.Radius + 5f) * 2.5f;
			if (Sector is SolarSystem)
			{
				num = (Sector.Radius + 15f) * 2.2f;
			}
			Vector3 targetSize = Vector3.one * num;
			targetSize.z = 1f;
			RevealBlob.transform.localScale = Vector3.zero;
			while (RevealBlob.transform.localScale.x < targetSize.x)
			{
				RevealBlob.transform.localScale = Vector3.Lerp(RevealBlob.transform.localScale, targetSize, Time.deltaTime * 100f);
				yield return true;
			}
		}
	}
}
