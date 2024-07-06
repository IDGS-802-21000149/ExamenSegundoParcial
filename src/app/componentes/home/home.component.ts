import { Component } from '@angular/core';
import { IProducto } from '../../interfaces/producto';
import { ProductoService } from '../producto.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  listaProductos: IProducto[] = [];

  constructor(private productoService: ProductoService) {
    this.getAllProductos();
   }
  

   getAllProductos() {
    this.productoService.getList().subscribe(result => {
      this.listaProductos = result;
    });
  }

}