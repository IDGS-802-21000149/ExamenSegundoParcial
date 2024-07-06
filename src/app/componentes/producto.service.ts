import { Injectable } from '@angular/core';
import{HttpClient} from '@angular/common/http';
import { environment } from '../../environments/environment.development';
import { Observable } from 'rxjs';
import { IProducto } from '../interfaces/producto';

@Injectable({
  providedIn: 'root'
})
export class ProductoService {

  private _endpoint: string = environment.endpoint;
  private _url: string = this._endpoint + 'Tareas/';

  constructor(private http: HttpClient) { }
  
  getList():Observable<IProducto[]>{    
    return this.http.get<IProducto[]>(`${this._url}ListaTareas`);
  }
 
  getListCategory1():Observable<IProducto[]>{  
    const categoria = 'CATEGORIA1'; // Replace 'your_category_value' with the actual category value you want to use
    return this.http.get<IProducto[]>(`${this._url}TareasPorCategoria/${categoria}`);
  }
  getListCategory2():Observable<IProducto[]>{  
    const categoria = 'CATEGORIA2'; // Replace 'your_category_value' with the actual category value you want to use
    return this.http.get<IProducto[]>(`${this._url}TareasPorCategoria/${categoria}`);
  }
  getListCategory3():Observable<IProducto[]>{  
    const categoria = 'CATEGORIA3'; // Replace 'your_category_value' with the actual category value you want to use
    return this.http.get<IProducto[]>(`${this._url}TareasPorCategoria/${categoria}`);
  }


  
}
