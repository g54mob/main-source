using CTS.Core;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class DependencyVoyager : MonoSingleton<DependencyVoyager>
	{
		public enum Dependency
		{
			LockAll = 0,
			Bar = 1,
			Interim = 2,
			CraftBar = 3
		}

		[SerializeField]
		private Button _bar;

		[SerializeField]
		private Button _interim;

		[SerializeField]
		private Button _craft;

		private Dependency _currentDependency;

		public Dependency CurrentDependency
		{
			get
			{
				return _currentDependency;
			}
			set
			{
				_currentDependency = value;
				_bar.interactable = _currentDependency != Dependency.Bar && _currentDependency != Dependency.LockAll;
				_interim.interactable = _currentDependency != Dependency.Interim && _currentDependency != Dependency.LockAll;
				_craft.interactable = _currentDependency != Dependency.CraftBar && _currentDependency != Dependency.LockAll;
			}
		}

		private void Start()
		{
			_bar.onClick.AddListener(GoToBar);
			_interim.onClick.AddListener(GoToInterim);
			_craft.onClick.AddListener(GoToCraftBar);
		}

		private void GoToBar()
		{
			CurrentDependency = Dependency.LockAll;
		}

		private void GoToInterim()
		{
			CurrentDependency = Dependency.LockAll;
			MonoSingleton<InterimAgency>.Instance.GoToAgency();
		}

		private void GoToCraftBar()
		{
			CurrentDependency = Dependency.LockAll;
			MonoSingleton<CocktailsCraftBar>.Instance.GoToCraftBar();
		}

		protected override void SingletonAwake()
		{
		}

		protected override void OnSingletonDestroy()
		{
		}
	}
}
