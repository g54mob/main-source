using UnityEngine;

[DisallowMultipleComponent]
public class SeasonObjectAuthoring : MonoBehaviour
{
	public Season belongsToSeason;

	public bool removeFromWorldWhenOutOfSeason;
}
