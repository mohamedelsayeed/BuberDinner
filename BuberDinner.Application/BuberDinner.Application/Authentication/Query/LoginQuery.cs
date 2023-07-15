﻿using BuberDinner.Application.Authentication.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuberDinner.Application.Authentication.Query;

public record LoginQuery(string Email, string Password) : IRequest<AuthenticationResult>;
