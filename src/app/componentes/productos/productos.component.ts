import { Component } from '@angular/core';
import { IProducto } from '../../interfaces/producto';
import { ProductoService } from '../producto.service';

@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrls: ['./productos.component.css']
})
export class ProductosComponent {
  listaProductosCAT0: IProducto[] = [];
  listaProductosCAT1: IProducto[] = [];
  listaProductosCAT2: IProducto[] = [];
  listaProductosCAT3: IProducto[] = [];
  productosFiltrados: IProducto[] = [];
  categoriaActual: string = 'CAT0'; // Categoría actual para mostrar
  terminoBusqueda: string = ''; // Término de búsqueda

  constructor(private productoService: ProductoService) {
    this.getCategoria1();
    this.getCategoria2();
    this.getCategoria3();
    this.getCategoria0();
  }

  getCategoria0() {
    this.productoService.getList().subscribe(result => {
      this.listaProductosCAT0 = result;
      this.filtrarProductos();
    });
  }

  getCategoria1() {
    this.productoService.getListCategory1().subscribe(result => {
      this.listaProductosCAT1 = result;
      this.filtrarProductos();
    });
  }

  getCategoria2() {
    this.productoService.getListCategory2().subscribe(result => {
      this.listaProductosCAT2 = result;
      this.filtrarProductos();
    });
  }

  getCategoria3() {
    this.productoService.getListCategory3().subscribe(result => {
      this.listaProductosCAT3 = result;
      this.filtrarProductos();
    });
  }

  mostrarCategoria(categoria: string) {
    this.categoriaActual = categoria;
    this.filtrarProductos();
  }

  filtrarProductos() {
    let lista = [];

    if (this.categoriaActual === 'CAT1') {
      lista = this.listaProductosCAT1;
    } else if (this.categoriaActual === 'CAT2') {
      lista = this.listaProductosCAT2;
    } else if (this.categoriaActual === 'CAT3') {
      lista = this.listaProductosCAT3;
    } else {
      lista = this.listaProductosCAT0.concat(this.listaProductosCAT1, this.listaProductosCAT2, this.listaProductosCAT3);
    }

    if (this.terminoBusqueda.trim() !== '') {
      this.productosFiltrados = lista.filter(producto =>
        producto.nombre.toLowerCase().includes(this.terminoBusqueda.toLowerCase()) ||
        producto.descripcion.toLowerCase().includes(this.terminoBusqueda.toLowerCase())
      );
    } else {
      this.productosFiltrados = lista;
    }
  }
}
