//Persistence Layer
//==============================================================================

global using Microsoft.EntityFrameworkCore;
global using Microsoft.AspNetCore.Identity;
global using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.AspNetCore.Http;

//Domain Layer
global using ChatApp.Domain.Entities;

//Application Layer
global using ChatApp.Application.Interfaces;
global using ChatApp.Application.Interfaces.Services;

//Persistence Layer
global using ChatApp.Persistence.DatabaseContext;