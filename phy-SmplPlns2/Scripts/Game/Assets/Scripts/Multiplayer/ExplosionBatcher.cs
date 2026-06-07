using System;
using System.Collections.Generic;
using Assets.Scripts.Flight;
using UnityEngine;

namespace Assets.Scripts.Multiplayer
{
	public class ExplosionBatcher
	{
		private readonly List<CreateExplosionInfo> _explosions = new List<CreateExplosionInfo>();

		private Dictionary<string, float> _blastRadiuses = new Dictionary<string, float>();

		public ExplosionBatcher()
		{
			_blastRadiuses["BombExplosion"] = 80f;
			_blastRadiuses["BombExplosionCleaver"] = 80f;
			_blastRadiuses["GeneralExplosion"] = 6f;
			_blastRadiuses["GroundVehicleBulletDamageExplosion"] = 8f;
			_blastRadiuses["MissileExplosion"] = 20f;
			_blastRadiuses["RocketExplosion"] = 25f;
			_blastRadiuses["ShipBulletDamageExplosion"] = 8f;
		}

		public void AddExplosion(CreateExplosionInfo newExplosion)
		{
			CreateExplosionInfo createExplosionInfo = newExplosion;
			if (!_blastRadiuses.TryGetValue(newExplosion.ExplosionPrefabName, out var value))
			{
				Debug.Log("Could not determine blast radius of explosion prefab '" + newExplosion.ExplosionPrefabName + "'");
				value = 10f;
			}
			for (int i = 0; i < 10; i++)
			{
				bool flag = false;
				for (int j = 0; j < _explosions.Count; j++)
				{
					if (CanCombine(createExplosionInfo, _explosions[j], value))
					{
						CombineInto(_explosions[j], createExplosionInfo);
						createExplosionInfo = _explosions[j];
						_explosions.RemoveAt(j);
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					_explosions.Add(createExplosionInfo);
					return;
				}
			}
			_explosions.Add(createExplosionInfo);
		}

		public void GetNextExplosions(int maxCount, List<CreateExplosionInfo> explosions)
		{
			int num = Math.Min(maxCount, _explosions.Count);
			if (num != 0)
			{
				_explosions.Sort((CreateExplosionInfo a, CreateExplosionInfo b) => a.ExplosionScale.CompareTo(b.ExplosionScale));
				while (num > 0)
				{
					int index = _explosions.Count - 1;
					explosions.Add(_explosions[index]);
					_explosions.RemoveAt(index);
					num--;
				}
			}
		}

		private bool CanCombine(CreateExplosionInfo a, CreateExplosionInfo b, float blastRadius)
		{
			if (a.ImpactType != b.ImpactType || a.AttackerPlayerId != b.AttackerPlayerId || a.ExplosionPrefabName != b.ExplosionPrefabName)
			{
				return false;
			}
			double sqrMagnitude = (a.GlobalPosition - b.GlobalPosition).sqrMagnitude;
			float num = (a.ExplosionScale + b.ExplosionScale) * blastRadius;
			return sqrMagnitude < (double)(num * num);
		}

		private void CombineInto(CreateExplosionInfo destination, CreateExplosionInfo source)
		{
			float num = destination.ExplosionScale + source.ExplosionScale;
			if (!(num <= 0f))
			{
				destination.GlobalPosition = (destination.GlobalPosition * destination.ExplosionScale + source.GlobalPosition * source.ExplosionScale) / num;
				destination.ExplosionScale = num;
				if (destination.BlastDirection.HasValue && source.BlastDirection.HasValue)
				{
					destination.BlastDirection = (destination.BlastDirection.Value + source.BlastDirection.Value).normalized;
				}
				else if (source.BlastDirection.HasValue)
				{
					destination.BlastDirection = source.BlastDirection;
				}
			}
		}
	}
}
