using System.Collections.Generic;
using UnityEngine;

public class CurseBlastMA : ManualAttack
{
	public static CurseBlastMA instance;

	private List<Hp> cursedHps = new List<Hp>();

	private List<TaggedObject> cursedTags = new List<TaggedObject>();

	private List<GameObject> cursedMarkers = new List<GameObject>();

	[SerializeField]
	private GameObject cursedMarkerPrefab;

	[SerializeField]
	private GameObject curseBlastFX;

	[SerializeField]
	private GameObject activatePlayerFX;

	[SerializeField]
	private Transform playerFXOrigin;

	[SerializeField]
	private AudioSource blastAudio;

	private void Awake()
	{
		instance = this;
	}

	public void AddCursedHp(Hp _hp, Weapon _immediatelyDamageEverybodyWith, TaggedObject _attacked, float _damageMultiplyer)
	{
		foreach (Hp cursedHp in cursedHps)
		{
			_immediatelyDamageEverybodyWith.DealDamage(cursedHp, _damageMultiplyer, null);
		}
		if (!cursedHps.Contains(_hp))
		{
			cursedHps.Add(_hp);
			_attacked.AddTag(TagManager.ETag.VodooCursed);
			cursedTags.Add(_attacked);
			GameObject item = Object.Instantiate(cursedMarkerPrefab, _hp.transform.position, Quaternion.identity, _hp.transform);
			cursedMarkers.Add(item);
		}
	}

	public override void Attack()
	{
		Object.Instantiate(activatePlayerFX, playerFXOrigin.position, Quaternion.identity).AddComponent<FollowTransform>().target = playerFXOrigin;
		blastAudio.pitch = Random.Range(0.9f, 1.1f);
		blastAudio.Play();
		foreach (Hp cursedHp in cursedHps)
		{
			weapon.DealDamage(cursedHp, base.AttackDamageMultiplyer, null);
			if (cursedHp != null)
			{
				Object.Instantiate(curseBlastFX, cursedHp.gameObject.transform.position, Quaternion.identity).AddComponent<FollowTransform>().target = cursedHp.gameObject.transform;
			}
		}
		cursedHps.Clear();
		foreach (TaggedObject cursedTag in cursedTags)
		{
			cursedTag.RemoveTag(TagManager.ETag.VodooCursed);
		}
		cursedTags.Clear();
		foreach (GameObject cursedMarker in cursedMarkers)
		{
			if (cursedMarker != null)
			{
				Object.Destroy(cursedMarker);
			}
		}
		cursedMarkers.Clear();
	}
}
