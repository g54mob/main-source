using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

namespace UI
{
	[RequireComponent(typeof(Image))]
	public class MapExtendDialogIcon : MonoBehaviour
	{
		private Image iconImage;

		private MstMachineDataEntities machineData;

		private Queue<eMachine> requestMachines;

		private bool loading;

		private int enableFrame;

		private void Awake()
		{
		}

		private void InitComponent()
		{
		}

		private void Update()
		{
		}

		public void Init(eMachine machine, int delay)
		{
		}

		public void Load(eMachine machine)
		{
		}

		private void ChangeSprite()
		{
		}

		private void SpriteLoaded(AsyncOperationHandle<Sprite> obj)
		{
		}

		private string GetSpritePath()
		{
			return null;
		}
	}
}
