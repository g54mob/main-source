using System.Collections.Generic;

public class AkRoomManager
{
	private readonly List<AkRoomPortal> m_Portals;

	private readonly List<AkRoomPortal> m_PortalsToUpdate;

	private readonly List<AkSurfaceReflector> m_Reflectors;

	private readonly List<AkSurfaceReflector> m_ReflectorsToUpdate;

	private static AkRoomManager m_Instance;

	public static void Init()
	{
	}

	public static void Terminate()
	{
	}

	public static void RegisterPortal(AkRoomPortal portal)
	{
	}

	public static void UnregisterPortal(AkRoomPortal portal)
	{
	}

	public static void RegisterReflector(AkSurfaceReflector reflector)
	{
	}

	public static void UnregisterReflector(AkSurfaceReflector reflector)
	{
	}

	public static void RegisterPortalUpdate(AkRoomPortal portal)
	{
	}

	public static void RegisterRoomUpdate(AkRoom room)
	{
	}

	public static void Update()
	{
	}
}
