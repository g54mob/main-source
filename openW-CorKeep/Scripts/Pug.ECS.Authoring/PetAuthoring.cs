using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PetAuthoring : MonoBehaviour
{
	public PetType petType;

	public bool isFlying;

	public List<PetTalent> petTalents;

	public float happyAnimDuration;
}
