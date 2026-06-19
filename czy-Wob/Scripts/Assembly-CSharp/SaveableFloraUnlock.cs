using System;
using System.Collections.Generic;

[Serializable]
public class SaveableFloraUnlock
{
	public string key;

	public bool floraDiscovered;

	public List<string> foodListDiscoveries = new List<string>();

	public List<GutFloraMutationEffect> floraEffectDiscoveries = new List<GutFloraMutationEffect>();

	public bool floraDiscoveryRecognized;

	public List<string> recognizedFoodListDiscoveries = new List<string>();

	public List<GutFloraMutationEffect> recognizedFloraEffectDiscoveries = new List<GutFloraMutationEffect>();

	public SaveableFloraUnlock(FloraUnlockInfo infoRef, string keyString)
	{
		foodListDiscoveries.Clear();
		floraEffectDiscoveries.Clear();
		key = keyString;
		floraDiscovered = infoRef.floraDiscovered;
		foodListDiscoveries.AddRange(infoRef.foodListDiscoveries);
		floraEffectDiscoveries.AddRange(infoRef.floraEffectDiscoveries);
		floraDiscoveryRecognized = infoRef.floraDiscoveryRecognized;
		recognizedFoodListDiscoveries.AddRange(infoRef.recognizedFoodListDiscoveries);
		recognizedFloraEffectDiscoveries.AddRange(infoRef.recognizedFloraEffectDiscoveries);
	}
}
