using Services.Save;
using UnityEngine;
using Zenject;

namespace UI.MainMenu
{
	public class SaveServiceHandler : MonoBehaviour
	{
		[Inject]
		private ISaveService _saveService;

		public void RemoveSaveData()
		{
			_saveService.DeleteAll();
		}
	}
}
