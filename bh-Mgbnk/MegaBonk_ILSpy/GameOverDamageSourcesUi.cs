using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Cpp2ILInjected;
using UnityEngine;

public class GameOverDamageSourcesUi : MonoBehaviour
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<DamageSource, float> _003C_003E9__2_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal float _003CStart_003Eb__2_0(DamageSource ds)
		{
			return ds.damage;
		}
	}

	public GameObject damageSourcePrefab;

	public Transform damageSourceParent;

	private unsafe void Start()
	{
		//IL_0067: Expected O, but got Ref
		Dictionary<string, DamageSource>.ValueCollection values = RunStats.damageSources.Values;
		Func<DamageSource, float> keySelector = _003C_003Ec._003C_003E9__2_0;
		if (_003C_003Ec._003C_003E9__2_0 == null)
		{
			keySelector = (_003C_003Ec._003C_003E9__2_0 = (Func<object, float>)((DamageSource ds) => ds.damage));
		}
		IOrderedEnumerable<DamageSource> source = Enumerable.OrderByDescending(values, keySelector);
		List<object> list = Enumerable.ToList((IEnumerable<object>)source);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		DamageSource damageSource = default(DamageSource);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				bool flag = damageSource == null;
				List<object>.Enumerator enumerator2 = (List<object>.Enumerator)(&enumerator);
				if (!flag)
				{
					if (damageSource.damageSource != "Unknown" && damageSource.damageSource != "Unkown" && !string.IsNullOrEmpty(damageSource.damageSource))
					{
						GameObject gameObject = UnityEngine.Object.Instantiate(damageSourcePrefab, damageSourceParent);
						if ((object)gameObject == null)
						{
							throw new NullReferenceException();
						}
						gameObject.SetActive(value: true);
						Transform transform = gameObject.transform;
						if ((object)transform == null)
						{
							break;
						}
						transform.parentInternal = damageSourceParent;
						DamageSourceEntry component = gameObject.GetComponent<DamageSourceEntry>();
						component.Set(damageSource);
					}
					continue;
				}
				throw new NullReferenceException();
			}
			((List<DamageSource>.Enumerator*)(&enumerator))->Dispose();
			return;
		}
		throw new NullReferenceException();
	}
}
