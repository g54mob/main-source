public enum AkPluginType : byte
{
	AkPluginTypeNone = 0,
	AkPluginTypeCodec = 1,
	AkPluginTypeSource = 2,
	AkPluginTypeEffect = 3,
	AkPluginTypeMixer = 6,
	AkPluginTypeSink = 7,
	AkPluginTypeGlobalExtension = 8,
	AkPluginTypeMetadata = 9,
	AkPluginType_Last = 10,
	AkPluginTypeMask = 15
}
