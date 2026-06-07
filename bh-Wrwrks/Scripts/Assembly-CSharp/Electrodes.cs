using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Electrodes : Module
{
	public GameObject lineObj;

	private List<ProjectileLine> lines = new List<ProjectileLine>();

	private Vector3 GetClosest(Vector3 start, List<Vector3> list, List<Vector3> exclude)
	{
		float num = 9999f;
		Vector3 result = start;
		foreach (Vector3 item in list)
		{
			if (!exclude.Contains(item))
			{
				float num2 = Vector3.Distance(start, item);
				if (Vector3.Distance(start, item) < num)
				{
					num = num2;
					result = item;
				}
			}
		}
		return result;
	}

	public override IEnumerator Increment()
	{
		List<Vector3> weps = new List<Vector3>();
		Color color = Utils.GetColor("FFC825");
		while (true)
		{
			foreach (ProjectileLine line3 in lines)
			{
				UnityEngine.Object.Destroy(line3.gameObject);
			}
			lines.Clear();
			List<Module> network = base.board.GetNetwork(this);
			weps.Clear();
			foreach (Module item3 in network)
			{
				if (item3.weapon == null)
				{
					continue;
				}
				switch (item3.name)
				{
				case Name.Shuriken:
					foreach (GameObject projectile in item3.weapon.GetComponent<Shuriken>().projectiles)
					{
						if (projectile != null)
						{
							weps.Add(projectile.transform.position);
						}
					}
					weps.Add(item3.weapon.transform.position);
					break;
				case Name.Bow:
					foreach (GameObject projectile2 in item3.weapon.GetComponent<Bow>().projectiles)
					{
						if (projectile2 != null)
						{
							weps.Add(projectile2.transform.position);
						}
					}
					weps.Add(item3.weapon.transform.position);
					break;
				case Name.Bolt:
					foreach (GameObject projectile3 in item3.weapon.GetComponent<Bolt>().projectiles)
					{
						if (projectile3 != null)
						{
							weps.Add(projectile3.transform.position);
						}
					}
					weps.Add(item3.weapon.transform.position);
					break;
				case Name.Clown:
					foreach (GameObject projectile4 in item3.weapon.GetComponent<Clown>().projectiles)
					{
						if (projectile4 != null)
						{
							weps.Add(projectile4.transform.position);
						}
					}
					weps.Add(item3.weapon.transform.position);
					break;
				case Name.Necromancy:
					foreach (Necro_Skele skeleton in item3.weapon.GetComponent<Necromancy>().skeletonList)
					{
						if (skeleton != null)
						{
							weps.Add(skeleton.transform.position);
						}
					}
					weps.Add(item3.weapon.transform.position);
					break;
				default:
					weps.Add(item3.weapon.transform.position);
					break;
				}
			}
			if (weps.Count < 2)
			{
				yield return Dungeon.Wait(1);
				continue;
			}
			List<(Vector3, Vector3)> list = new List<(Vector3, Vector3)>();
			List<Vector3> list2 = new List<Vector3>();
			list2.Add(weps[0]);
			foreach (Vector3 item4 in weps)
			{
				_ = item4;
				foreach (Vector3 item5 in weps)
				{
					if (!list2.Contains(item5))
					{
						Vector3 closest = GetClosest(list2.Last(), weps, list2);
						if (closest == list2.Last())
						{
							break;
						}
						list2.Add(closest);
					}
				}
			}
			for (int i = 0; i < list2.Count; i++)
			{
				Vector3 vector = list2[i];
				Vector3 vector2 = ((i != list2.Count - 1) ? list2[i + 1] : list2[0]);
				if (vector == vector2)
				{
					continue;
				}
				list.Add((vector, vector2));
				ProjectileLine component = UnityEngine.Object.Instantiate(lineObj).GetComponent<ProjectileLine>();
				component.transform.parent = base.transform;
				LineRenderer line = component.line;
				float startWidth = (component.line.endWidth = 0.09f);
				line.startWidth = startWidth;
				LineRenderer line2 = component.line;
				Color startColor = (component.line.endColor = color);
				line2.startColor = startColor;
				List<Vector3> list3 = new List<Vector3>();
				list3.Add(vector);
				list3.Add(Vector3.Lerp(vector, vector2, 0.25f + UnityEngine.Random.Range(-0.1f, 0.1f)));
				list3.Add(Vector3.Lerp(vector, vector2, 0.5f + UnityEngine.Random.Range(-0.1f, 0.1f)));
				list3.Add(Vector3.Lerp(vector, vector2, 0.75f + UnityEngine.Random.Range(-0.1f, 0.1f)));
				list3.Add(vector2);
				List<Vector3> list4 = new List<Vector3>();
				int num2 = 0;
				foreach (Vector3 item6 in list3)
				{
					list4.Add(item6);
					num2++;
					if (item6 == list3.Last())
					{
						break;
					}
					Vector3 vector3 = list3[num2];
					float num3 = Vector3.Distance(vector3, item6);
					if (!(Vector3.Distance(vector3, item6) < 0.5f))
					{
						_ = (vector3 - item6).normalized;
						float num4 = Mathf.Atan2(0f - item6.y + vector3.y, 0f - item6.x + vector3.x);
						float num5 = num4 + MathF.PI / 180f * (float)UnityEngine.Random.Range(5, 20);
						float num6 = num4 - MathF.PI / 180f * (float)UnityEngine.Random.Range(5, 20);
						float num7 = UnityEngine.Random.Range(0.1f, 0.5f);
						float num8 = UnityEngine.Random.Range(num7 + 0.2f, 0.8f);
						Vector3 item = item6 + new Vector3(Mathf.Cos(num5), Mathf.Sin(num5)) * num3 * num7;
						Vector3 item2 = item6 + new Vector3(Mathf.Cos(num6), Mathf.Sin(num6)) * num3 * num8;
						list4.Add(item);
						list4.Add(item2);
					}
				}
				foreach (Vector3 item7 in list4)
				{
					component.UpdateLine(item7);
				}
				component.projectile.sourceModule = this;
				component.projectile.sharedWeapon = true;
				lines.Add(component);
			}
			yield return Dungeon.Wait(1);
			while (bankItem)
			{
				yield return Dungeon.Wait(1);
			}
		}
	}
}
