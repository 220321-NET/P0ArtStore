﻿using BL;
using DL; 

namespace UI;


string connectionString = File.ReadAllText("./connectionString.txt");
IRepository repo = new DbRepository(connectionString);
IAsbl bl = new Asbl(repo);
ArtHomeMain bl = new ArtHomeMain(repo).Start();
