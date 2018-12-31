﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Saar.FFmpeg.CSharp;

namespace SaarFFmpeg.H264Output {
	class Program {
		static void Main(string[] args) {
			var reader = new MediaReader(@"a.avi");
			var decoder = reader.Decoders.OfType<VideoDecoder>().First();
			var packet = new Packet();
			using (var writer = new MediaRemuxer(@"v.h264", decoder)) {
				while (reader.ReadPacket(packet, decoder.StreamIndex)) {
					writer.Write(packet);
				}
			}

            Console.ReadLine();
		}
	}
}
