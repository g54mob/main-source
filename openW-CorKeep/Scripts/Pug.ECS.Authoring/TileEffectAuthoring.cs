using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class TileEffectAuthoring : MonoBehaviour
{
	public SFXTableIDField sfxTableDamageId;

	public SFXTableIDField sfxTableDestroyId;

	public List<PuffParams> destroyPuffs;
}
