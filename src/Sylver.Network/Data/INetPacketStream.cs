﻿using System;
using System.IO;

namespace Sylver.Network.Data
{
    public interface INetPacketStream : IDisposable
    {
        /// <summary>
        /// Gets the packet stream state.
        /// </summary>
        NetPacketStateType State { get; }

        /// <summary>
        /// Gets a value that indicates if the current cursor is at the end of the packet stream.
        /// </summary>
        bool IsEndOfStream { get; }

        /// <summary>
        /// Gets the length of the packet stream.
        /// </summary>
        long Length { get; }

        /// <summary>
        /// Gets the current position of the cursor in the packet stream.
        /// </summary>
        long Position { get; }

        /// <summary>
        /// Gets the packet stream buffer.
        /// </summary>
        byte[] Buffer { get; }

        /// <summary>
        /// Reads a T value from the packet stream.
        /// </summary>
        /// <typeparam name="T">Type of the value</typeparam>
        /// <returns>The value read and converted to the type.</returns>
        T Read<T>();

        /// <summary>
        /// Writes a T value in the packet stream.
        /// </summary>
        /// <typeparam name="T">Type of the value.</typeparam>
        /// <param name="value">Value to write in the packet stream.</param>
        void Write<T>(T value);

        /// <summary>
        /// Sets the position within the current stream to the specified value.
        /// </summary>
        /// <param name="offset">The new position within the stream. This is relative to the loc parameter, and can be positive or negative.</param>
        /// <param name="loc">A value of type <see cref="T:System.IO.SeekOrigin"></see>, which acts as the seek reference point.</param>
        /// <returns>
        /// The new position within the stream, calculated by combining the initial 
        /// reference point and the offset.
        /// </returns>
        long Seek(long offset, SeekOrigin loc);
    }
}