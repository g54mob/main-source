using System.Collections.Generic;

public class BlockCopyPaster
{
	private MultiDictionary<int, Socket.Connections> socketConnections;

	private List<Construction.BlockInScheme> doubleBufferCtrlc;

	private List<Construction.BlockInScheme> doubleBufferScheme;

	private Dictionary<Construction.BlockInScheme, Construction.BlockInScheme> destinationToRealLink;

	public BlockCopyPaster(List<Construction.BlockInScheme> blocks)
	{
		socketConnections = new MultiDictionary<int, Socket.Connections>();
		doubleBufferCtrlc = new List<Construction.BlockInScheme>();
		doubleBufferScheme = new List<Construction.BlockInScheme>(blocks);
		destinationToRealLink = new Dictionary<Construction.BlockInScheme, Construction.BlockInScheme>();
	}

	public Construction.BlockInScheme GetRealObject(Construction.BlockInScheme newBlock)
	{
		return destinationToRealLink[newBlock];
	}

	public List<Construction.BlockInScheme> Scheme()
	{
		return doubleBufferScheme;
	}

	public List<Construction.BlockInScheme> Buffer()
	{
		return doubleBufferCtrlc;
	}

	public bool IsEmpty()
	{
		return doubleBufferCtrlc.Count == 0;
	}

	public bool HasSocketConnections()
	{
		return socketConnections.Count != 0;
	}

	public void Add(Construction.BlockInScheme newBlock, Construction.BlockInScheme socketRefBlock)
	{
		Socket.Connections value = socketRefBlock.BlockData().GetSocketConnections();
		socketConnections.Add(socketRefBlock.GetUniqueHash(), value);
		doubleBufferCtrlc.Add(newBlock);
		destinationToRealLink.Add(newBlock, socketRefBlock);
	}

	public void Clear()
	{
		foreach (Construction.BlockInScheme item in doubleBufferCtrlc)
		{
			item.Destroy(deleteChains: true, invoke: false);
		}
		socketConnections.Clear();
		doubleBufferCtrlc.Clear();
		doubleBufferScheme.Clear();
		destinationToRealLink.Clear();
	}

	public HashSet<Socket.Connections> GetSocketConnections(int hash)
	{
		HashSet<Socket.Connections> value = null;
		if (socketConnections.TryGetValue(hash, out value))
		{
			return value;
		}
		return null;
	}

	public HashSet<Socket.Connections> GetSocketConnections(Construction.BlockInScheme block)
	{
		return GetSocketConnections(block.GetUniqueHash());
	}
}
