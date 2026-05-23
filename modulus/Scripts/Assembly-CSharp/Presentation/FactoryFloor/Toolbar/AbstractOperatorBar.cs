using UnityEngine;

namespace Presentation.FactoryFloor.Toolbar
{
	public abstract class AbstractOperatorBar : MonoBehaviour
	{
		public int BuildingFamily;

		private bool _isInitalized;

		public BuildMode BuildMode { get; set; }

		public void Initalize()
		{
			if (!_isInitalized)
			{
				_isInitalized = true;
				InitalizeInternal();
			}
		}

		protected abstract void InitalizeInternal();

		public abstract void Show();

		public abstract void Hide();
	}
}
