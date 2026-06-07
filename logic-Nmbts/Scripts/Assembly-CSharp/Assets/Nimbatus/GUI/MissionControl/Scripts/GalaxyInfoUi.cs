using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.Persistence;
using Sirenix.OdinInspector;

namespace Assets.Nimbatus.GUI.MissionControl.Scripts
{
	public class GalaxyInfoUi : SerializedMonoBehaviour
	{
		public UILabel GalaxyLabel;

		public void Update()
		{
			if (SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy != null)
			{
				GalaxyLabel.text = "Galaxy #" + SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy.Level;
			}
		}
	}
}
