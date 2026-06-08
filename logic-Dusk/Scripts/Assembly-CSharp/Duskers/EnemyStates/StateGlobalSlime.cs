using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Duskers.EnemyStates
{
	public class StateGlobalSlime : BaseEnemyState
	{
		private const float HIBERNATE_CHECK_TIME = 1f;

		private const float SPLIT_CHECK_WAIT_TIME = 5f;

		private SlimeBrain _slimeBrain;

		private float _hibernateCheckTimer;

		private float _splitCheckTimer;

		public override string StateId
		{
			get
			{
				return "GlobalSlime";
			}
		}

		public override event ChangeStateDelegate ChangeState;

		public StateGlobalSlime(BaseEnemyBrain brain)
			: base(brain)
		{
			_slimeBrain = (SlimeBrain)brain;
		}

		public override void Update()
		{
			if (GlobalSettings.GameIsOver && _brain.CurrentState != "Nil")
			{
				ChangeState(_brain.StateNil);
				return;
			}
			if (_brain.ThisEnemy.IsDead && !_slimeBrain.SlimeEnemy.IsHibernating)
			{
				SlimeEnemy slimeEnemy = _slimeBrain.OtherSlimes.LastOrDefault((SlimeEnemy x) => !x.IsDead);
				if (slimeEnemy != null)
				{
					_slimeBrain.PassBrainToSlime(slimeEnemy);
				}
				else
				{
					ChangeState(_brain.StateNil);
				}
			}
			_hibernateCheckTimer -= Time.deltaTime;
			if (_hibernateCheckTimer <= 0f)
			{
				_hibernateCheckTimer = 1f;
				if (!_slimeBrain.SlimeEnemy.IsHibernating && _slimeBrain.SlimeEnemy.ShouldLeaveCurrentRoom())
				{
					_slimeBrain.SlimeEnemy.ForceHibernation();
					_slimeBrain.OtherSlimes.ForEach(delegate(SlimeEnemy x)
					{
						x.ForceHibernation();
					});
				}
			}
			if (_slimeBrain.CheckForSplit)
			{
				_splitCheckTimer -= Time.deltaTime;
				if (_splitCheckTimer <= 0f)
				{
					_splitCheckTimer = 5f;
					CheckForSlimeSplit();
					_slimeBrain.CheckForSplit = false;
				}
			}
		}

		private void CheckForSlimeSplit()
		{
			float num = _slimeBrain.SlimeEnemy.transform.localScale.x / 2f + _slimeBrain.SlimeEnemy.transform.localScale.x;
			List<SlimeEnemy> list = new List<SlimeEnemy>();
			List<SlimeEnemy> list2 = new List<SlimeEnemy>();
			_slimeBrain.SlimeEnemy.TempEnemies.Clear();
			list.Add(_slimeBrain.SlimeEnemy);
			list2.Add(_slimeBrain.SlimeEnemy);
			foreach (SlimeEnemy otherSlime in _slimeBrain.OtherSlimes)
			{
				otherSlime.TempEnemies.Clear();
				if (!otherSlime.IsDead)
				{
					list.Add(otherSlime);
				}
			}
			foreach (SlimeEnemy item in list)
			{
				foreach (SlimeEnemy item2 in list)
				{
					if (!(item == item2))
					{
						float num2 = Vector3.Distance(item.Position, item2.Position);
						if (num2 <= num)
						{
							item.TempEnemies.Add(item2);
						}
					}
				}
			}
			foreach (SlimeEnemy otherSlime2 in _slimeBrain.OtherSlimes)
			{
				if (!otherSlime2.IsDead)
				{
					_slimeBrain.OtherSlimes.ForEach(delegate(SlimeEnemy x)
					{
						x.TempTag = false;
					});
					if (IsAdjacentToEnemyRecursive(otherSlime2, _slimeBrain.SlimeEnemy))
					{
						list2.Add(otherSlime2);
					}
				}
			}
			if (list2.Count == list.Count)
			{
				return;
			}
			int num3 = 0;
			SlimeBrain slimeBrain = null;
			foreach (SlimeEnemy item3 in list)
			{
				if (!list2.Contains(item3))
				{
					num3++;
					_slimeBrain.OtherSlimes.Remove(item3);
					if (slimeBrain == null)
					{
						slimeBrain = new SlimeBrain(item3);
						item3.SetBrain(slimeBrain);
						slimeBrain.Initialize();
					}
					else
					{
						slimeBrain.OtherSlimes.Add(item3);
					}
					item3.SlimeBrainId = slimeBrain.Id;
				}
			}
			Debug.Log(string.Format("Split {0} slimes from brain {1} to new brain {2}", num3, _slimeBrain.Id, (slimeBrain == null) ? "n/a" : slimeBrain.Id.ToString()));
		}

		private bool IsAdjacentToEnemyRecursive(BaseEnemy sourceEnemy, BaseEnemy targetEnemy)
		{
			bool flag = false;
			sourceEnemy.TempTag = true;
			if (sourceEnemy.TempEnemies.Contains(targetEnemy))
			{
				flag = true;
			}
			else
			{
				foreach (BaseEnemy tempEnemy in sourceEnemy.TempEnemies)
				{
					if (!tempEnemy.TempTag)
					{
						flag = IsAdjacentToEnemyRecursive(tempEnemy, targetEnemy);
						if (flag)
						{
							break;
						}
					}
				}
			}
			return flag;
		}

		public override void EnterState()
		{
		}

		public override void ExitState()
		{
		}

		public virtual IState GetStunReturnState()
		{
			return _brain.StatePatrol;
		}
	}
}
