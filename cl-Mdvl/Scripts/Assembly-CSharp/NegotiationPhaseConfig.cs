using Managers;
using NSMedieval.Serialization;
using NSMedieval.State;

[FVSerializableKey("NegotiationPhaseConfig", "")]
public struct NegotiationPhaseConfig : IFVSerializable
{
	public string ChatGraphId;

	public NewsData NewsMessage;

	public int? WontNegotiateWithWorkerId;

	public string WontNegotiateWithWorkerBBTTextKey;

	public int CountdownDurationMinutes;

	public string CountdownText;

	public string CountdownTooltip;

	public string CountdownIcon;

	public HumanoidInstance UseExistingNegotiatorNPC;

	public bool SpawnCampfire;

	public void Serialize(FVSerializer serializer)
	{
		serializer.Write("ChatGraphId", ChatGraphId);
		serializer.Write("NewsMessage", NewsMessage);
		serializer.Write("WontNegotiateWithWorkerId", WontNegotiateWithWorkerId);
		serializer.Write("WontNegotiateWithWorkerBbtTextKey", WontNegotiateWithWorkerBBTTextKey);
		serializer.Write("CountdownText", CountdownText);
		serializer.Write("CountdownTooltip", CountdownTooltip);
		serializer.Write("CountdownIcon", CountdownIcon);
		serializer.Write("CountdownDurationMinutes", CountdownDurationMinutes);
		serializer.Write("UseExistingNegotiatorNPC", UseExistingNegotiatorNPC);
		serializer.Write("SpawnCampfire", SpawnCampfire);
	}

	public NegotiationPhaseConfig(FVDeserializer deserializer)
	{
		ChatGraphId = deserializer.ReadString("ChatGraphId");
		NewsMessage = deserializer.ReadObject<NewsData>("NewsMessage");
		WontNegotiateWithWorkerId = deserializer.ReadNullableInt("WontNegotiateWithWorkerId");
		WontNegotiateWithWorkerBBTTextKey = deserializer.ReadString("WontNegotiateWithWorkerBbtTextKey");
		CountdownText = deserializer.ReadString("CountdownText");
		CountdownTooltip = deserializer.ReadString("CountdownTooltip");
		CountdownIcon = deserializer.ReadString("CountdownIcon");
		CountdownDurationMinutes = deserializer.ReadInt("CountdownDurationMinutes");
		UseExistingNegotiatorNPC = deserializer.ReadObject<HumanoidInstance>("UseExistingNegotiatorNPC");
		SpawnCampfire = deserializer.ReadBool("SpawnCampfire", UseExistingNegotiatorNPC == null);
	}
}
