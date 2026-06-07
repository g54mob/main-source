using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using Zenject;

namespace VampireSurvivors.Objects
{
	public abstract class Equipment : GameMonoBehaviour
	{
		protected DataManager _dataManager;

		protected JObject _currentJsonDataObject;

		protected SignalBus _signalBus;

		protected LevelUpFactory _levelUpFactory;

		private WeaponType _equipmentType;

		public int Level { get; set; }

		public int LevelsNumber { get; set; }

		public WeaponType Type
		{
			get
			{
				return default(WeaponType);
			}
			protected set
			{
			}
		}

		public CharacterController Owner { get; set; }

		public bool ShowInRecap { get; set; }

		protected virtual void FakeConstruct()
		{
		}

		public virtual bool IsPowerup()
		{
			return false;
		}

		public virtual void Cleanup()
		{
		}

		public abstract bool LevelUp(bool skipFire = false);

		public abstract void CheckArcanas();

		public abstract void InternalUpdate();

		protected abstract Dictionary<WeaponType, JArray> GetDataDictionary();

		protected abstract void MakeLevelOne();

		protected virtual bool GetDataForLevel(WeaponType type, int level, out JObject newLevelData, bool upgradeExistingData = true)
		{
			newLevelData = null;
			return false;
		}

		public bool IsMaxLevel()
		{
			return false;
		}

		public bool IsEvolution()
		{
			return false;
		}

		public int GetLevelsNumber()
		{
			return 0;
		}

		private void EditorPrintDataAsJson()
		{
		}
	}
}
