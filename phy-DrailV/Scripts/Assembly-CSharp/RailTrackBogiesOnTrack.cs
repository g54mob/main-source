using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class RailTrackBogiesOnTrack : MonoBehaviour
{
	public HashSet<Bogie> bogiesOnTrack = new HashSet<Bogie>();
}
