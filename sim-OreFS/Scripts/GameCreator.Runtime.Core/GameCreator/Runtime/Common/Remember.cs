using System;
using System.Threading.Tasks;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[HelpURL("https://docs.gamecreator.io/gamecreator/advanced/save-load-game/remember")]
	[AddComponentMenu("Game Creator/Save & Load/Remember")]
	[DefaultExecutionOrder(50)]
	[DisallowMultipleComponent]
	public class Remember : MonoBehaviour, IGameSave
	{
		[SerializeField]
		private SaveUniqueID m_SaveUniqueID = new SaveUniqueID(save: true);

		[SerializeField]
		private Memories m_Memories = new Memories();

		[field: NonSerialized]
		internal bool IsDestroying { get; private set; }

		internal bool IsSceneLoaded => base.gameObject.scene.isLoaded;

		public string SaveID => m_SaveUniqueID.Get.String;

		public bool IsShared => false;

		public Type SaveType => m_Memories.SaveType;

		public LoadMode LoadMode => LoadMode.Lazy;

		private void Awake()
		{
			SaveLoadManager.Subscribe(this);
		}

		private void OnDestroy()
		{
			IsDestroying = true;
			SaveLoadManager.Unsubscribe(this);
		}

		public object GetSaveData(bool includeNonSavable)
		{
			if (!m_SaveUniqueID.SaveValue)
			{
				return null;
			}
			return m_Memories.GetTokens(base.gameObject);
		}

		public Task OnLoad(object value)
		{
			m_Memories.OnRemember(base.gameObject, value as Tokens);
			return Task.FromResult(result: true);
		}
	}
}
