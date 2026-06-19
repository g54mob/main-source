using System.Collections.Generic;

public class FloraUnlockInfo
{
	public bool floraDiscovered;

	public bool floraDiscoveryRecognized;

	public List<string> foodList = new List<string>();

	public List<string> foodListDiscoveries = new List<string>();

	public List<string> recognizedFoodListDiscoveries = new List<string>();

	public List<GutFloraMutationEffect> floraEffects = new List<GutFloraMutationEffect>();

	public List<GutFloraMutationEffect> floraEffectDiscoveries = new List<GutFloraMutationEffect>();

	public List<GutFloraMutationEffect> recognizedFloraEffectDiscoveries = new List<GutFloraMutationEffect>();
}
