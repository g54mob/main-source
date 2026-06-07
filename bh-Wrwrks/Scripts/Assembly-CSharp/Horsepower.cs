using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horsepower : MonoBehaviour
{
	private Dictionary<Aura, int> buffs = new Dictionary<Aura, int>();

	public void AddBuff(Module m)
	{
		Aura aura = new Aura(Aura.Type.Damage);
		m.AddAura(aura);
		buffs.Add(aura, 120);
	}

	private void Start()
	{
		StartCoroutine(buffer());
	}

	private IEnumerator buffer()
	{
		List<Aura> removes = new List<Aura>();
		while (true)
		{
			foreach (KeyValuePair<Aura, int> item in new Dictionary<Aura, int>(buffs))
			{
				if (item.Value <= 0)
				{
					removes.Add(item.Key);
				}
				else
				{
					buffs[item.Key]--;
				}
			}
			foreach (Aura item2 in removes)
			{
				item2.owner.RemoveAura(item2);
				buffs.Remove(item2);
			}
			removes.Clear();
			yield return Dungeon.Wait(1);
		}
	}
}
