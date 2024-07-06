import { Component } from '@angular/core';
import { Routes } from '@angular/router';
import path from 'path';
import { HomeComponent } from './componentes/home/home.component';
import { ContactoComponent } from './componentes/contacto/contacto.component';
import { ProductosComponent } from './componentes/productos/productos.component';

export const routes: Routes = [

    {path: 'contacto', component: ContactoComponent},
    {path: 'productos', component: ProductosComponent},
    {path: 'home', component: HomeComponent},
    {path:'', redirectTo: '/home', pathMatch: 'full'},

];
