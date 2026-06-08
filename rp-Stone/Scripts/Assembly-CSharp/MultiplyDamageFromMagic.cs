using UnityEngine;

[RequireComponent(typeof(Character))]
public class MultiplyDamageFromMagic : MonoBehaviour
{
	public float multiplier = 2f;

	public string singleTag = "magic";

	public string[] multiTags;

	private Character myCharacter;

	private void HandleGoingToTakeDamage(Character c, Damage dmg)
	{
		if (!(c == myCharacter))
		{
			return;
		}
		bool flag = !string.IsNullOrEmpty(singleTag) && dmg.tags.Contains(singleTag);
		int num = 0;
		while (!flag && multiTags != null && num < multiTags.Length)
		{
			if (dmg.tags.Contains(multiTags[num]))
			{
				flag = true;
				break;
			}
			num++;
		}
		if (!flag && dmg.isCritical)
		{
			if (singleTag == "critical")
			{
				flag = true;
			}
			else
			{
				int num2 = 0;
				while (multiTags != null && num2 < multiTags.Length)
				{
					if (multiTags[num2] == "critical")
					{
						flag = true;
					}
					num2++;
				}
			}
		}
		if (flag)
		{
			dmg.amount = Mathf.RoundToInt((float)dmg.amount * multiplier);
		}
	}

	private void Start()
	{
		Character.OnCharacterGoingToTakeDamage += HandleGoingToTakeDamage;
		myCharacter = GetComponent<Character>();
	}

	private void OnDestroy()
	{
		Character.OnCharacterGoingToTakeDamage -= HandleGoingToTakeDamage;
		myCharacter = null;
	}
}
