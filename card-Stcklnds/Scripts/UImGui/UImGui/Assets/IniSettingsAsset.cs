using UnityEngine;

namespace UImGui.Assets
{
	[CreateAssetMenu(menuName = "Dear ImGui/Ini Settings")]
	internal sealed class IniSettingsAsset : ScriptableObject
	{
		[TextArea(3, 20)]
		[SerializeField]
		private string _data;

		public void Save(string data)
		{
			_data = data;
		}

		public string Load()
		{
			return _data;
		}
	}
}
