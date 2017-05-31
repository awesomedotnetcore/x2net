﻿// Copyright (c) 2017 Jae-jun Kang
// See the file LICENSE for details.

namespace x2net.xpiler
{
    /// <summary>
    /// DefinitionUnit file handler interface.
    /// </summary>
    interface Handler
    {
        bool Handle(string path, out Unit unit);
    }
}
